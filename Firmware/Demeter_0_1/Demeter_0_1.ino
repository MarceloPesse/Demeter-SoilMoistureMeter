#include <Wire.h>

#include <DemeterMCP.h>
#include <DemeterADC.h>
#include <DemeterDHT.h>
#include <DemeterCOM.h>

#include "DemeterPIN.h"

demeterMCP mcp;
demeterADC adc;
demeterDHT dht;
demeterCOM com;

#define BOARD_ID 1
String id;

Board board = { 6, 5,
                7, 5,
                4, 5 };

Sensor sensor1 = {SEN_5V1, SEN_3V1, SEN_LED1, SEN_SN1, SEN_ADC1 };
Sensor sensor2 = {SEN_5V2, SEN_3V2, SEN_LED2, SEN_SN2, SEN_ADC2 };
Sensor sensor3 = {SEN_5V3, SEN_3V3, SEN_LED3, SEN_SN3, SEN_ADC3 };

#define b_max 4
char buff[b_max+1];

void setup() {
  com.begin(XBEE_RESET, RS485_EN);
  mcp.begin();
  dht.begin(SEN_DHT);
  
  sensorBegin(&sensor1);
  sensorBegin(&sensor2);
  sensorBegin(&sensor3);
  
  id = String(BOARD_ID, HEX);
  if(BOARD_ID < 16){
    id.concat(id[0]);
    id.setCharAt(0, '0');
  }
  id.toUpperCase();
}

void loop() {
  while (Serial1.available() > 0){
    for(int i = 0; i < b_max; i++){
      buff[i] = buff[i+1];
    }
    buff[b_max] = Serial1.read();
    if(buff[0] == '#' & buff[1] == id[0] & buff[2] == id[1] & buff[3] == ':'){
      if(buff[4] == '1') com.sensor(BOARD_ID, 1, board.sen1, sensorRead(&sensor1, board.ten1)/2 );
      if(buff[4] == '2') com.sensor(BOARD_ID, 2, board.sen2, sensorRead(&sensor2, board.ten2)/2 );
      if(buff[4] == '3') com.sensor(BOARD_ID, 3, board.sen3, sensorRead(&sensor3, board.ten3)/2 );
      if(buff[4] == '4') com.sensor(BOARD_ID, 4, 1, dht.temperature() );
      if(buff[4] == '5') com.sensor(BOARD_ID, 5, 2, dht.humidity() );
    }
  }
}

void sensorBegin (Sensor* sensor){
  mcp.pinMode(sensor->v5, OUTPUT);
  mcp.pinMode(sensor->v3, OUTPUT);
  mcp.pinMode(sensor->led, OUTPUT);
  mcp.pinMode(sensor->sen, INPUT);

  mcp.digitalWrite(sensor->v5, HIGH);
  mcp.digitalWrite(sensor->v3, HIGH);
  mcp.digitalWrite(sensor->led, HIGH);
}

int32_t sensorRead (Sensor* sensor, byte tensao){
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
