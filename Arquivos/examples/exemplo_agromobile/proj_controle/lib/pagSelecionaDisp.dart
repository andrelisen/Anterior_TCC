import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'conexaoBlue.dart';
import 'pagSelectViagem.dart';

class SelecionaDispositivo extends StatelessWidget {
  final String nome;

  SelecionaDispositivo(this.nome);

  @override
  Widget build(BuildContext context) {
    return SelectBondedDevicePage(
      onCahtPage: (device1) {
        BluetoothDevice device = device1;
        print("Endereço do dispositivo é: ");
        print(device.address.toString()); //98:D3:41:FD:3D:79
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) {
              // return ImprimeDados(server: device); //inicialmente ia p/ imprimir dados
              return PaginaSelectViagem(
                  device, nome); //agora vai p/ pág init viagem
            },
          ),
        );
      },
    );
  }
}
