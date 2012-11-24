#define XBEE_RESET 4
#define XBEE_DTR 12
#define XBEE_CTS 6
#define XBEE_RTS 8

#define SEN_DHT 9

#define RS485_EN 11

#define SEN_LED1 13
#define SEN_LED2 12
#define SEN_LED3 11
#define SEN_SN1 8
#define SEN_SN2 9
#define SEN_SN3 10

#define SEN_5V1 0
#define SEN_3V1 1
#define SEN_5V2 2
#define SEN_3V2 3
#define SEN_5V3 4
#define SEN_3V3 5

#define SEN_ADC1 1
#define SEN_ADC2 2
#define SEN_ADC3 3

#define EE_BOARD 0
#define EE_SEN1 1
#define EE_TEN1 2
#define EE_SEN2 3
#define EE_TEN2 4
#define EE_SEN3 5
#define EE_TEN3 6

struct Sensor{
  uint8_t v5;
  uint8_t v3;
  uint8_t led;
  uint8_t sen;
  uint8_t adc;
};

struct Board{
  uint8_t sen1;
  uint8_t ten1;
  uint8_t sen2;
  uint8_t ten2;
  uint8_t sen3;
  uint8_t ten3;
};
