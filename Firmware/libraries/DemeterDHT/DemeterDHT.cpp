#include "DemeterDHT.h"

DHT::DHT(uint8_t pin) {
  _pin = pin;
  firstreading = true;
}

void DHT::begin(void) {
  pinMode(_pin, INPUT);
  digitalWrite(_pin, HIGH);
  _lastreadtime = 0;
}

float DHT::readTemperature(void) {
  float f;

  if (read()) {
    f = data[2];
    return f;
  }
  Serial.print("Read fail");
  return NAN;
}

float DHT::readHumidity(void) {
  float f;
  if (read()) {
    f = data[0];
    return f;
  }
  Serial.print("Read fail");
  return NAN;
}

boolean DHT::read(void) {
  uint8_t laststate = HIGH;
  uint8_t counter = 0;
  uint8_t j = 0, i;
  unsigned long currenttime;

  // pull the pin high and wait 250 milliseconds
  digitalWrite(_pin, HIGH);
  delay(250);

  currenttime = millis();
  if (currenttime < _lastreadtime) {
    // ie there was a rollover
    _lastreadtime = 0;
  }
  if (!firstreading && ((currenttime - _lastreadtime) < 2000)) {
    return true; // return last correct measurement
    //delay(2000 - (currenttime - _lastreadtime));
  }
  firstreading = false;
  
  _lastreadtime = millis();

  data[0] = data[1] = data[2] = data[3] = data[4] = 0;
  
  // now pull it low for ~20 milliseconds
  pinMode(_pin, OUTPUT);
  digitalWrite(_pin, LOW);
  delay(20);
  
  // block interrupts until we have finhised things
  cli();
  
  digitalWrite(_pin, HIGH);
  delayMicroseconds(40);
  pinMode(_pin, INPUT);

  // read in timings
  for ( i=0; i< MAXTIMINGS; i++) {
    counter = 0;
    while (digitalRead(_pin) == laststate) {
      counter++;
      delayMicroseconds(1);
      if (counter == 255) {
        break;
      }
    }
    laststate = digitalRead(_pin);

    if (counter == 255) break;

    // ignore first 3 transitions
    if ((i >= 4) && (i%2 == 0)) {
      // shove each bit into the storage bytes
      data[j/8] <<= 1;
      if (counter > 6)
        data[j/8] |= 1;
      j++;
    }

  }
  
  // resume interupts
  sei();

  // check we read 40 bits and that the checksum matches
  if ((j >= 40) && 
      (data[4] == ((data[0] + data[1] + data[2] + data[3]) & 0xFF)) ) {
    return true;
  }
  return false;
}
