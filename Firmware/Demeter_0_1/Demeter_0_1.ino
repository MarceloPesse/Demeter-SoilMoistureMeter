#include <Wire.h>
#include <DemeterMCP.h>
#include <DemeterADC.h>

#include "DemeterPIN.h"

demeterMCP mcp;
demeterADC adc;

Sensor sensor1 = {SEN_5V1, SEN_3V1, SEN_LED1, SEN_SN1, SEN_ADC1 };
Sensor sensor2 = {SEN_5V2, SEN_3V2, SEN_LED2, SEN_SN2, SEN_ADC2 };
Sensor sensor3 = {SEN_5V3, SEN_3V3, SEN_LED3, SEN_SN3, SEN_ADC3 };

#define ID 1

void setup() {
  Serial.begin(9600); 
  Serial1.begin(9600);
  
  pinMode(XBEE_RESET, OUTPUT);
  digitalWrite(XBEE_RESET, HIGH);
  
  mcp.begin();
  
  sensorbegin(&sensor1);
  sensorbegin(&sensor2);
  sensorbegin(&sensor3);
}

void loop() {
  if (Serial1.available() > 0){
    if (Serial1.read() == 49){
      Serial1.print("1:");
      Serial1.print(sensorread(&sensor1, 5) );
      Serial1.print(" 2:");
      Serial1.print(sensorread(&sensor2, 5) );
      Serial1.print(" 3:");
      Serial1.println(sensorread(&sensor3, 5) );
    }
  }
}

void sensorbegin (Sensor* sensor){
  mcp.pinMode(sensor->v5, OUTPUT);
  mcp.pinMode(sensor->v3, OUTPUT);
  mcp.pinMode(sensor->led, OUTPUT);
  mcp.pinMode(sensor->sen, INPUT);

  mcp.digitalWrite(sensor->v5, HIGH);
  mcp.digitalWrite(sensor->v3, HIGH);
  mcp.digitalWrite(sensor->led, HIGH);
}

int32_t sensorread (Sensor* sensor, byte tensao){
  mcp.digitalWrite(sensor->led, LOW);
  
  if (tensao = 5) mcp.digitalWrite(sensor->v5, LOW);
  else mcp.digitalWrite(sensor->v3, LOW);
  
  delay(100);
  
  int32_t data;
  adc.config(sensor->adc);
  if (!adc.read(data)) Serial.print("Error");
  
  mcp.digitalWrite(sensor->v5, HIGH);
  mcp.digitalWrite(sensor->v3, HIGH);
  
  mcp.digitalWrite(sensor->led, HIGH);
  
  return data;
}
