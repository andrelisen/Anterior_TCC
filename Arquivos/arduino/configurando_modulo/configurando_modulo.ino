#include "SoftwareSerial.h"

//Código de configuração do MÓDULO HC-05 
//Pino key conectado no 3.3v do Arduino
//Os outros conectores RX e TX seguem a lógica anterior de comunicação
////////////////////////////////////////////////////////////////////////
//Principais comandos AT
//AT - retorna OK // serve para verificar se tá tudo certo com a conexão c módulo
//AT+NAME? = Retorna nome atual d módulo
//AT+NAME=novo_nome = Troca nome do módulo
//AT+PSWD? = Retorna senha atual
//AT+PSWD='mudarsenha' = Serve para trocar a senha 
//AT+ROLE? = verifica o estado do módulo 0 - slave, 1 - master e 2 - loopback
//AT+ROLE=num = Trocar estado do módulo
//AT+UART=115200,1,0 = Mudar baud - PADRÃO = +UART:9600,0,0
void setup() {
  Serial.begin(38400);
  Serial.println("Digite os comandos AT: ");
  Serial2.begin(38400);
}


void loop() {
  if(Serial2.available()){
    int isByte = Serial2.read();
    Serial.write((char)isByte);
  }
  if(Serial.available()){
    int isByte = Serial.read();
    Serial2.write((char)isByte);
  }
}
