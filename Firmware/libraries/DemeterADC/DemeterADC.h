#ifndef _DemeterADC_H_
#define _DemeterADC_H_

class demeterADC{
 public:
  void config(uint8_t channel);
  uint8_t read(int32_t &data);
  
 private:
  uint8_t adcConfig;
};

#endif