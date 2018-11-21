
void setup() {
  // put your setup code here, to run once:
  Serial.begin (9600);
  pinMode(13, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(5, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  int peticion = Serial.read();
  switch(peticion)
  {
    case '1': // Caso para prender las luces del patio
      digitalWrite(13, HIGH);
    break;
    case '2':
      digitalWrite(13, LOW);
    break;
    case '3':// Caso para prender y apagar las luces de la entrada
      digitalWrite(12, HIGH);
    break;
    case '4':
      digitalWrite(12, LOW);
    case '5':
      digitalWrite(11, HIGH); // Caso para prender y apagar las luces del pasillo
    break;
    case '6':
      digitalWrite(11, LOW);
    break;
    // Cosina
    case '7':
      digitalWrite(10, HIGH);
    break;
    case '8':
      digitalWrite(10, LOW);
    break;
    // Sala
    case '9':
      digitalWrite(9, HIGH); 
    break;
    case 'A':
      digitalWrite(9, LOW);
    break;
    // Dormitorio
    case 'B':
      digitalWrite(8, HIGH);
    break;
    case 'C':
      digitalWrite(8, LOW);
    break;
    // Baño
    case 'D':
      digitalWrite(7, HIGH);
    break;
    case 'E':
      digitalWrite(7, LOW);
    break;
    // Cuarto de juegos
    case 'F':
      digitalWrite(6, HIGH);
    break;
    case 'J':
      digitalWrite(6, LOW);
    break;
    // Cochera
    case 'H':
      digitalWrite(5, HIGH); 
    break;
    case 'I':
      digitalWrite(5, LOW);
    break;
  }
  delay(700);
  
}
