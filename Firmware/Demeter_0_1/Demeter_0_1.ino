#include <Wire.h>
#include <DemeterMCP.h>
#include <DemeterADC.h>

#include "DemeterPIN.h"

demeterMCP mcp;
demeterADC adc;

Sensor sensor1 = {SEN_5V1, SEN_3V1, SEN_LED1, SEN_SN1, SEN_ADC1 };
Sensor sensor2 = {SEN_5V2, SEN_3V2, SEN_LED2, SEN_SN2, SEN_ADC2 };
Sensor sensor3 = {SEN_5V3, SEN_3V3, SEN_LED3, SEN_SN3, SEN_ADC3 };

void setup() {
  Serial.begin(9600); 
  Serial.println("Demeter");
  
  pinMode(XBEE_RESET, OUTPUT);
  digitalWrite(XBEE_RESET, HIGH);
  
  mcp.begin();
  
  sensorbegin(&sensor1);
  sensorbegin(&sensor2);
  sensorbegin(&sensor3);
}

void loop() {
  Serial.print("1:");
  Serial.print(sensorread(&sensor1, 5) );
  //delay(1000);
  Serial.print(" 2:");
  Serial.print(sensorread(&sensor2, 5) );
  //delay(1000);
  Serial.print(" 3:");
  Serial.println(sensorread(&sensor3, 5) );
  //delay(1000);
  /*mcp.digitalWrite(sensor1.v5, LOW);
  
  int32_t data;
  adc.config(1);
  if (!adc.read(data)) Serial.print("Error"); 
  Serial.print("data: ");
  Serial.println(data);
  delay(1000);*/
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
