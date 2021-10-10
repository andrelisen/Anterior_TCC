#include <SerialCommand.h>
//Faz comunicação com o arduino enviando informação para mover para a direita ou esquerda
//Recebe a direcao
//Emite uma mensagem do sistema quando necessário enviar o log da partida
//Tudo isso usando módulo HC-05
//Posição lógica das entradas: branco, cinza [branco = TX2(RX), cinza = RX2(TX)]

char direcao;
String readString;


void setup() {
  //Seta porta serial de comunicação
  Serial.begin(9600);
  Serial2.begin(9600); //TX2, RX2 
  //led apenas para testes de recebimento/envio de dados
  pinMode(53, OUTPUT);
}

void loop() {
  //Se houve recebimento de alguma informação
  while(Serial2.available()){
    delay(5);
    direcao = Serial2.read();  

    readString += direcao;

    
//    Serial.write(Serial2.read());
//    Serial.flush();
//    delay(20);
   
//    if(direcao == 'H'){
//      digitalWrite(53, HIGH);
//      Serial2.write("1");
//      Serial.write(1);
//      delay(20);
//    }
//
//    if(direcao == 'L'){
//      digitalWrite(53, LOW);
//      Serial2.write("0");
//      Serial.write(2);
//      delay(20);
//    }
    
  }

  if (readString.length() >0) {
//    Serial2.print("Ok!");
    float myVar = readString.toFloat();
    readString += '\n';
    Serial.print(readString);
    Serial.flush();
    delay(50);
    readString="";
  }

}
