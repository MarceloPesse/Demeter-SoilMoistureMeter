#include "Arduino.h"

#define MAXTIMINGS 85

class DHT {
 private:
  uint8_t data[6];
  uint8_t _pin;
  boolean read(void);
  unsigned long _lastreadtime;
  boolean firstreading;

 public:
  DHT(uint8_t pin);
  void begin(void);
  float readTemperature(void);
  float readHumidity(void);

};
