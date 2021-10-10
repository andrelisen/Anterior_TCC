#include <SerialCommand.h>
//Faz comunicação com o arduino enviando informação para mover para a direita ou esquerda
//Recebe a direcao
//Emite uma mensagem do sistema quando necessário enviar o log da partida
//Tudo isso usando módulo HC-05
//Posição lógica das entradas: branco, cinza [branco = TX2(RX), cinza = RX2(TX)]

bool sData = true;
bool lagConnection = false;
bool flagHand = false;

void setup() {
  //Seta porta serial de comunicação
  Serial.begin(115200);
  Serial2.begin(115200); //TX2, RX2 
  Serial.flush();
  Serial2.flush();
  //led apenas para testes de recebimento/envio de dados
  pinMode(53, OUTPUT);
}

void loop() {
  if(Serial2.available() && flagHand == true){
      Serial.write(Serial2.read());
      sData = false;
  }
  if(sData == true){
    Serial.write("Stop\n"); //4 ou 5 caracteres
  }
  if(Serial.available() && lagConnection == false){ 
    if(Serial.read() == '1'){ //conexão com unity estabelecida
      digitalWrite(53, HIGH); 
      delay(10);
      digitalWrite(53, LOW);
      delay(10);
      Serial2.write("1"); 
      lagConnection = true;
      flagHand = true;
    }
  }

  //comunicaçao smartphone - arduino - unity
//  if(Serial2.available()){
//    int isByte = Serial2.read();
////    Serial.write((char)isByte);
//     Serial.print(Serial2.read());
//    Serial2.flush();
//  }
//  delay(50);

  //Comunicaçao unity - arduino 
//  if(Serial.available()){
//    data = Serial.read();
//    if(data == '1'){
//      digitalWrite(53, HIGH);
//      delay(1000);
//      digitalWrite(53, LOW);
//      delay(1000);
//    }
//  }
  
  //Códigos abaixo funcionam mas com bug de delay dos dados até a unity
  //Se houve recebimento de alguma informação
  //Comunicação do smartphone com o Arduino
//  while(Serial2.available()){
//      data = Serial2.read(); 
//      delay(50);
//      Serial.write(data);
//      //Serial.print(Serial2.read()); //escrever o que lê na porta serial para comunicar com a unity 
//      Serial.flush();
//      delay(20);    
//  }
  
    
}
