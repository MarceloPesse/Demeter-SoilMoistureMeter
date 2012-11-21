#include <Wire.h>
#include "DemeterADC.h"

#if ARDUINO >= 100
 #include "Arduino.h"
#else
 #include "WProgram.h"
#endif

// I2C address for MCP3422 - base address for MCP3424
#define MCP3422_ADDRESS 0X68

#define MCP342X_GAIN_X1    0X00 // PGA gain X1
#define MCP342X_18_BIT     0X0C // 18-bit 3.75 SPS
#define MCP342X_ONESHOT 0X00 // 1 = continuous, 0 = one-shot

#define MCP342X_START      0X80 // write: start a conversion
#define MCP342X_BUSY       0X80 // read: output not ready

// default adc congifuration register - chanel added in config()
uint8_t adcConfig = MCP342X_START | MCP342X_ONESHOT | MCP342X_18_BIT | MCP342X_GAIN_X1 | MCP342X_ONESHOT;


void demeterADC::config(uint8_t channel) {
  if (channel > 4) channel = 4;
  channel = channel - 1; // Channel between 0 and 3
  
  adcConfig = MCP342X_START | MCP342X_ONESHOT | MCP342X_18_BIT | MCP342X_GAIN_X1 | MCP342X_ONESHOT;
  adcConfig |= channel << 5;
  
  Wire.beginTransmission(MCP3422_ADDRESS);
  Wire.write(adcConfig);
  Wire.endTransmission();
}

uint8_t demeterADC::read(int32_t &data) {
  // pointer used to form int32 data
  uint8_t *p = (uint8_t *)&data;
  // timeout - not really needed?
  uint32_t start = millis();
  do {
    // assume 18-bit mode
    Wire.requestFrom(MCP3422_ADDRESS, 4);
    if (Wire.available() != 4) {
      Serial.println("read failed");
      return false;
    }
    for (int8_t i = 2; i >= 0; i--) {
      p[i] = Wire.read();
    }
    // extend sign bits
    p[3] = p[2] & 0X80 ? 0XFF : 0;
    // read config/status byte
    uint8_t s = Wire.read();
    if ((s & MCP342X_BUSY) == 0) return true;
  } while (millis() - start < 500); //allows rollover of millis()
  Serial.println("read timeout");
  return false;
}
