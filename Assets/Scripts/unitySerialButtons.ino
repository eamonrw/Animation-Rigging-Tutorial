#include <Adafruit_CircuitPlayground.h>

bool leftButtonPressed;
bool rightButtonPressed;

void setup() {
  Serial.begin(9600);
  CircuitPlayground.begin();
}

void loop() {
  //while you can test with print statements, the code will only work
  //in Unity if you only write data, i.e. no strings or anything should be printed
  leftButtonPressed = CircuitPlayground.leftButton();
  rightButtonPressed = CircuitPlayground.rightButton();

  //Serial.print("Left Button: ");
  if (leftButtonPressed) {
    //Serial.print("DOWN");
    Serial.write(1);
  } else {
    //Serial.print("  UP");
  }
  //Serial.print("   Right Button: ");
  if (rightButtonPressed) {
    //Serial.print("DOWN");
    Serial.write(2);
  } else {
    //Serial.print("  UP");
  }

  delay(20);
}
