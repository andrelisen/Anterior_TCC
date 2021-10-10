import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'package:proj_controle/pagSelecionaDisp.dart';

class PaginaLista extends StatelessWidget {
  final String nome;

  PaginaLista(this.nome);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('AgroMobile - Controle de carga'),
        centerTitle: true,
      ),
      body: FutureBuilder(
        future: FlutterBluetoothSerial.instance.requestEnable(),
        builder: (context, future) {
          if (future.connectionState == ConnectionState.waiting) {
            print("Esperando conexão...");
            return Scaffold(
              body: Container(
                height: double.infinity,
                child: Center(
                  child: Icon(
                    Icons.bluetooth_disabled,
                    size: 200.0,
                    color: Colors.green,
                  ),
                ),
              ),
            );
          } else if (future.connectionState == ConnectionState.done) {
            print("Conexão feita!");
            return SelecionaDispositivo(nome); //coleta dados do dispositivo e conecta
          } else {
            return SelecionaDispositivo(nome);
          }
        },
      ),
    );
  }
}
