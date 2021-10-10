import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'package:proj_controle/salvaDados.dart';

import 'pagCarga.dart';

class PaginaSelectViagem extends StatelessWidget {
  final BluetoothDevice server;
  final String nome;

  PaginaSelectViagem(this.server, this.nome);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('AgroMobile - Controle de carga'),
          centerTitle: true,
        ),
        body: Column(
          children: [
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 45, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 150,
                child: Image.asset('imagens/LogoAplicativo.png'),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 70, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 45,
                child: RaisedButton(
                  color: Colors.green[800],
                  textColor: Colors.white,
                  onPressed: () {
                    CapturarDados capturaLocalizacao = new CapturarDados();
                    capturaLocalizacao.capturarLocalizacaoParada(2);
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (BuildContext context) =>
                                PaginaCarga(server)));
                  },
                  child: Text('INICIAR VIAGEM', style: TextStyle(fontSize: 20)),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 150, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 120,
                height: 90,
                child: Image.asset('imagens/logoEmbrapa.png'),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 0, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 150,
                height: 100,
                child: Image.asset('imagens/logoUnipampa.png'),
              ),
            ),
          ],
        ));
  }
}
