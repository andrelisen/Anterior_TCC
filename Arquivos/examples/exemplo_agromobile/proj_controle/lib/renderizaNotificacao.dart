import 'package:flutter/material.dart';

class TelaMensagem extends StatelessWidget {
  // final String mensagem;
  final estado;
  final temperatura;
  final umidade;

  TelaMensagem(this.estado, this.temperatura, this.umidade);

  //estados atuais = animais tranquilos, animais estressados, animais muito estressados
  Widget cores() {
    if (estado == "0") {
      return Scaffold(
        backgroundColor: Colors.black54,
        body: Column(
          children: [
            Container(
              child: Icon(
                Icons.error_outline,
                size: 100,
                color: Colors.white,
              ),
              margin: const EdgeInsets.fromLTRB(
                  0, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  25, 50, 25, 0), //left, top, right, bottom
              alignment: Alignment.center,
              child: Text(
                'AGUARDANDO A PARTIDA DO VEÍCULO',
                style: TextStyle(fontSize: 26, color: Colors.white),
              ),
            ),
          ],
        ),
      );
    }
    if (estado == "1") {
      return Scaffold(
        backgroundColor: Colors.green,
        body: Column(
          children: [
            Container(
              child: Icon(
                Icons.error_outline,
                size: 100,
                color: Colors.white,
              ),
              margin: const EdgeInsets.fromLTRB(
                  0, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  0, 50, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
              child: Text(
                'ANIMAIS TRANQUILOS',
                style: TextStyle(fontSize: 26, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'TEMPERATURA $temperaturaºC',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 5, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'UMIDADE $umidade%',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
          ],
        ),
      );
    }
    if (estado == "2") {
      return Scaffold(
        backgroundColor: Colors.orange,
        body: Column(
          children: [
            Container(
              child: Icon(
                Icons.error_outline,
                size: 100,
                color: Colors.white,
              ),
              margin: const EdgeInsets.fromLTRB(
                  0, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  0, 50, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
              child: Text(
                'ANIMAIS ESTRESSADOS',
                style: TextStyle(fontSize: 26, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'TEMPERATURA $temperaturaºC',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 5, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'UMIDADE $umidade%',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
          ],
        ),
      );
    }
    if (estado == "3") {
      return Scaffold(
        backgroundColor: Colors.red,
        body: Column(
          children: [
            Container(
              child: Icon(
                Icons.error_outline,
                size: 100,
                color: Colors.white,
              ),
              margin: const EdgeInsets.fromLTRB(
                  0, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.center,
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  25, 50, 0, 25), //left, top, right, bottom
              alignment: Alignment.center,
              child: Text(
                'ANIMAIS MUITO ESTRESSADOS',
                style: TextStyle(fontSize: 26, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 200, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'TEMPERATURA $temperaturaºC',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(
                  10, 5, 0, 0), //left, top, right, bottom
              alignment: Alignment.bottomLeft,
              child: Text(
                'UMIDADE $umidade%',
                style: TextStyle(fontSize: 24, color: Colors.white),
              ),
            ),
          ],
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: cores(),
    );
  }
}
