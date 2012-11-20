#include "DemeterADC.h"

void setup() {
  Wire.begin();
  Serial.begin(9600); 
  Serial.println("ADC test!");
}

void loop() {
  int32_t data;
  
  ADC.config(1);
  
  if (!ADC.read(data)) Serial.print("Error"); 
  Serial.print("data: ");
  Serial.print(data);
  delay(1000);
}
