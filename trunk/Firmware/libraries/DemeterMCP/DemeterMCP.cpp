#include <Wire.h>
#include <avr/pgmspace.h>
#include "DemeterMCP.h"

#if ARDUINO >= 100
 #include "Arduino.h"
#else
 #include "WProgram.h"
#endif

// minihelper
static inline void wiresend(int x) {
#if ARDUINO >= 100
  Wire.write((int)x);
#else
  Wire.send(x);
#endif
}

static inline int wirerecv(void) {
#if ARDUINO >= 100
  return Wire.read();
#else
  return Wire.receive();
#endif
}

////////////////////////////////////////////////////////////////////////////////

void demeterMCP::begin(int addr) {
  if (addr > 7) {
    addr = 7;
  }
  i2caddr = addr;

  Wire.begin();

  
  // set defaults!
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(MCP23017_IODIRA);
  wiresend(0xFF);  // all inputs on port A
  Wire.endTransmission();

  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(MCP23017_IODIRB);
  wiresend(0xFF);  // all inputs on port B
  Wire.endTransmission();
}


void demeterMCP::begin(void) {
  begin(0);
}

void demeterMCP::pinMode(int p, int d) {
  int iodir;
  int iodiraddr;

  // only 16 bits!
  if (p > 15)
    return;

  if (p < 8)
    iodiraddr = MCP23017_IODIRA;
  else {
    iodiraddr = MCP23017_IODIRB;
    p -= 8;
  }

  // read the current IODIR
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(iodiraddr);	
  Wire.endTransmission();
  
  Wire.requestFrom(MCP23017_ADDRESS | i2caddr, 1);
  iodir = wirerecv();

  // set the pin and direction
  if (d == INPUT) {
    iodir |= 1 << p; 
  } else {
    iodir &= ~(1 << p);
  }

  // write the new IODIR
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(iodiraddr);
  wiresend(iodir);	
  Wire.endTransmission();
}

void demeterMCP::digitalWrite(int p, int d) {
  int gpio;
  int gpioaddr, olataddr;

  // only 16 bits!
  if (p > 15)
    return;

  if (p < 8) {
    olataddr = MCP23017_OLATA;
    gpioaddr = MCP23017_GPIOA;
  } else {
    olataddr = MCP23017_OLATB;
    gpioaddr = MCP23017_GPIOB;
    p -= 8;
  }

  // read the current GPIO output latches
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(olataddr);	
  Wire.endTransmission();
  
  Wire.requestFrom(MCP23017_ADDRESS | i2caddr, 1);
   gpio = wirerecv();

  // set the pin and direction
  if (d == HIGH) {
    gpio |= 1 << p; 
  } else {
    gpio &= ~(1 << p);
  }

  // write the new GPIO
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(gpioaddr);
  wiresend(gpio);	
  Wire.endTransmission();
}

void demeterMCP::pullUp(int p, int d) {
  int gppu;
  int gppuaddr;

  // only 16 bits!
  if (p > 15)
    return;

  if (p < 8)
    gppuaddr = MCP23017_GPPUA;
  else {
    gppuaddr = MCP23017_GPPUB;
    p -= 8;
  }


  // read the current pullup resistor set
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(gppuaddr);	
  Wire.endTransmission();
  
  Wire.requestFrom(MCP23017_ADDRESS | i2caddr, 1);
  gppu = wirerecv();

  // set the pin and direction
  if (d == HIGH) {
    gppu |= 1 << p; 
  } else {
    gppu &= ~(1 << p);
  }

  // write the new GPIO
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(gppuaddr);
  wiresend(gppu);	
  Wire.endTransmission();
}

int demeterMCP::digitalRead(int p) {
  int gpioaddr;

  // only 16 bits!
  if (p > 15)
    return 0;

  if (p < 8)
    gpioaddr = MCP23017_GPIOA;
  else {
    gpioaddr = MCP23017_GPIOB;
    p -= 8;
  }

  // read the current GPIO
  Wire.beginTransmission(MCP23017_ADDRESS | i2caddr);
  wiresend(gpioaddr);	
  Wire.endTransmission();
  
  Wire.requestFrom(MCP23017_ADDRESS | i2caddr, 1);
  return (wirerecv() >> p) & 0x1;
}
