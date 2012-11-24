#include "DemeterCOM.h"
#include "Math.h"

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

void demeterCOM::sensor(int board, int num, int id, unsigned int data) {
  
  Serial1.print("#");
  print(board,2);
  Serial1.print(":");
  print(num,1);
  Serial1.print(";");
  print(id,2);
  Serial1.print(":");
  print(data,4);
  // Send a \r\n
  Serial1.print("\r\n");
}

void demeterCOM::print(unsigned int data, int mag) {
  if (data >= pow(16,mag) ) Serial1.print("error");
  else {
    for (int i = 1; i < mag;i++){
      if(data < pow(16,i) ) {
        Serial.print("0");
        Serial1.print("0");
      }
    }
    Serial.print(data, HEX);
    Serial1.print(data, HEX);
  }
}
