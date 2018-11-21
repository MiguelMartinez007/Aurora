/*
  Ethernet Monitor Analogo
 By: http://www.elprofegarcia.com/
 Este programa usa el Modulo Ethernet de Arduino para monitorear las entradas analogicas A0-A5
 
 Conexiones:
 * Ethernet shield usa los pins 10, 11, 12, 13
 * Monitorea los pines Analogos de A0 a A5
 
Se debe conectar el modulo a la red local y se debe asignar una IP fija que no coincida
con los equipos de la red que ya estan funcionando pero dede estar dentro de la SubRed.
puede monitorear la IP de su PC dentro de la ventana de comandos CMD con el comando ipconfig
*/

#include <SPI.h>
#include <Ethernet.h>
                               // Introduzca una dirección MAC y la dirección IP para el controlador
byte mac[] = { 
0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
byte ip[] = {192,168,3,253};
byte gateway[] = {192,168,3,254};
byte subnet[] = {255,255,255,0};
String readString;


EthernetServer server(80);    // Puerto 80 por defecto para HTTP

void setup() {
  
  Serial.begin (9600);
  while(!Serial)
  {
    ;
  }
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  Ethernet.begin(mac, ip, gateway, subnet);    //inicializa la conexión Ethernet y el servidor
  server.begin();
  Serial.print("El servidor es: ");
  Serial.println(Ethernet.localIP());
  digitalWrite(2, HIGH);
}

void loop() {
  EthernetClient cliente = server.available(); // Inicializa cliente como servidor ethernet
  if (cliente) {
    boolean currentLineIsBlank = true;
    while (cliente.connected()) {
      if (cliente.available()) {
        char c = cliente.read();

        // Lee caracter por caracter HTTP
        if(readString.length() < 100)
        {
          // Almacena los caracteres en un string
          readString += c;
        }
        // Si el requerimiento HTTP fue finalizado        
        if (c == '\n') {
          //Serial.println(readString);

          
          cliente.println("HTTP/1.1 200 OK");
          cliente.println("Content-Type: text/html");   // Envia el encabezado en codigo HTML estandar
          cliente.println();
          cliente.println("<!DOCTYPE html>");
          cliente.println("<html> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0'> <title>iHouse</title> <style> * {padding: 0; margin: 0; } #botones {width: 100%; overflow: hidden; display: flex; flex-flow: row no-wrap; justify-content: center; align-items: stretch; } #botones a {display: block; width: 100%; max-width: 200px; margin: 10px; text-decoration: none; padding: 10px; background-color: #3479b0; color: #f9f9fa; font-weight: bold; transition: all; } #botones a p {text-align: center; } #botones a:hover {color: #3479b0; background-color: #f9f9fa; } #botones a#cerrar {background-color: #ec1d42; } #botones a#cerrar:hover {background-color: #f9f9fa; color: #ec1d42; } </style> </head> <body> <div id='botones'> <a href=\"/?button2on\"\"><p>Luces</p></a> <a id='cerrar' href=\"/?button2off\"\"><p>Apagar luces</p></a> </div> </body> </html>");

          delay(1);
          // Detine el cliente servidor
          cliente.stop();

          // Condicion de arduino si un boton es precionado
          if(readString.indexOf("?button2on") > 0)
          {
            Serial.println("ON");
            digitalWrite(2,HIGH);
          }
          if(readString.indexOf("?button2off") > 0)
          {
            Serial.println("OFF");
            digitalWrite(2,LOW);
          }

          // Limpia el String(Cadena de caracteres para una nueva lectura)
          readString = "";
        }
      }
    }
  }

  int peticion = Serial.read();
  switch(peticion)
  {
    case '1': // Caso para prender las luces del patio
      digitalWrite(2, HIGH);
    break;
    case '2':
      digitalWrite(2, LOW);
    break;
  }
}

