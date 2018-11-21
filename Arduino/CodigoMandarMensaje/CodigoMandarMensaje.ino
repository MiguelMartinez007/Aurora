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
IPAddress ip(192,168,1,253);   // Esta direccion IP debe ser cambiada obligatoriamente 
                              // dependiendo de la subred de su Area Local y es la que 
                              // usara para conectarse por el Navegador.

EthernetServer server(80);    // Puerto 80 por defecto para HTTP

void setup() {
  Ethernet.begin(mac, ip);    //inicializa la conexión Ethernet y el servidor
  server.begin();
}

void loop() {
  EthernetClient cliente = server.available(); // Inicializa cliente como servidor ethernet
  if (cliente) {
    boolean currentLineIsBlank = true;
    while (cliente.connected()) {
      if (cliente.available()) {
        char c = cliente.read();
        if (c == '\n' && currentLineIsBlank) { 
          cliente.println("HTTP/1.1 200 OK");
          cliente.println("Content-Type: text/html");   // Envia el encabezado en codigo HTML estandar
          cliente.println("Connection: close"); 
    cliente.println("Refresh: 3");  // refresca la pagina automaticamente cada 3 segundos
          cliente.println();
          //cliente.println("Hola a todos");
          break;
        }
        if (c == '\n') {
           currentLineIsBlank = true;
        } 
        else if (c != '\r') {
           currentLineIsBlank = false;
        }
      }
    }
   delay(15);           // Da tiempo al Servidor para que reciba los datos 15ms
   cliente.stop();     // cierra la conexion
  }
}
