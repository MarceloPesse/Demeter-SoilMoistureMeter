#ifndef _DemeterCOM_H_
#define _DemeterCOM_H_

#define COM_SPEED 9600

class demeterCOM{
 public:
  void begin(int reset, int enable);
  void sensor(int board, int num, int id, unsigned int data);
  void print(unsigned int data, int mag);
  
 private:

};

#endif