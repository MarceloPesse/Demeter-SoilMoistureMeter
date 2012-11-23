#include "DemeterCOM.h"

#if ARDUINO >= 100
 #include "Arduino.h"
#else
 #include "WProgram.h"
#endif

void demeterCOM::begin(int reset, int enable) {
  Serial.begin(COM_SPEED);
  Serial1.begin(COM_SPEED);
  
  Serial.print("Demeter - 0.1");
  
  pinMode(reset, OUTPUT);
  digitalWrite(reset, HIGH);
  
  pinMode(enable, OUTPUT);
}

void demeterCOM::print(int id, int32_t data) {  
  Serial.print(data, HEX);
  Serial1.print(data, HEX);
}
