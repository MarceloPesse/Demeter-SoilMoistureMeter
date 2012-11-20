#include "Arduino.h"
#include <Wire.h>

class ADC {
 private:
  uint8_t adcConfig;

 public:
  void config(uint8_t channel);
  uint8_t read(int32_t &data);
};
