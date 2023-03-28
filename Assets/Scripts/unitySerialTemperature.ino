#include <Adafruit_CircuitPlayground.h>
#include <Adafruit_Circuit_Playground.h>


float value;
float unityValue;

void setup() {
  Serial.begin(9600);
  CircuitPlayground.begin();
}

void loop() {
  value = CircuitPlayground.temperatureF();

  unityValue = map(value, 70, 100, 0, 100);

  Serial.println(unityValue); // Unity will read this value
  Serial.flush();
  delay(20); // This delay is important - 20 should be enough for a smooth transition.
}
