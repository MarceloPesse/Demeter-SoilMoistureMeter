#ifndef _DemeterCOM_H_
#define _DemeterCOM_H_

#define COM_SPEED 9600

class demeterCOM{
 public:
  void begin(int reset, int enable);
  void print(int id, int32_t data);
  
 private:

};

#endif