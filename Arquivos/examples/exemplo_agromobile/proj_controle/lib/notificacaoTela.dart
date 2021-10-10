import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'package:proj_controle/erroBluetooth.dart';
import 'package:proj_controle/pagCarga.dart';
import 'package:proj_controle/pagPergunta.dart';
import 'package:proj_controle/renderizaNotificacao.dart';
import 'package:sensors/sensors.dart';
import 'dart:math';

class NotificacoesTela extends StatefulWidget {
  final BluetoothDevice server;
  final int condicaoNotificacao;
  const NotificacoesTela(
      {this.server,
      this.condicaoNotificacao}); //recebo o end do dispositivo selecionado para conexão bluetooth

  @override
  _NotificacoesTela createState() => new _NotificacoesTela();
}

class _Message {
  int whom;
  String text;

  _Message(this.whom, this.text);
}

class _NotificacoesTela extends State<NotificacoesTela> {
  BluetoothConnection connection;

  List<_Message> messages = List<_Message>();

  final ScrollController listScrollController = new ScrollController();

  bool isConnecting = true;
  bool get isConnected => connection != null && connection.isConnected;

  bool isDisconnecting = false;

  var _estado = "";
  var _temperatura = "";
  var _umidade = "";
  String _messageBuffer = '';
  int _length;

  int _condicao;
  double velocity = 0; //velocidade inicial
  double highestVelocity = 0.0; //max velocidade
  bool valor = false;

  int contador = 0;
  int _controleTela = 0;
  void _recebendoDados() async {
    try {
      connection = await BluetoothConnection.toAddress(widget.server.address);
      // print('Connected to the device');

      connection.input.listen((Uint8List data) {
        // print('Data incoming: ${ascii.decode(data)}');
        // Allocate buffer for parsed data
        int backspacesCounter = 0;
        data.forEach((byte) {
          if (byte == 8 || byte == 127) {
            backspacesCounter++;
          }
        });
        Uint8List buffer = Uint8List(data.length - backspacesCounter);
        int bufferIndex = buffer.length;

        // Apply backspace control character
        backspacesCounter = 0;
        for (int i = data.length - 1; i >= 0; i--) {
          if (data[i] == 8 || data[i] == 127) {
            backspacesCounter++;
          } else {
            if (backspacesCounter > 0) {
              backspacesCounter--;
            } else {
              buffer[--bufferIndex] = data[i];
            }
          }
        }

        // Create message if there is new line character
        String dataString = String.fromCharCodes(buffer);
        int index = buffer.indexOf(13);
        if (~index != 0) {
          setState(() {
            messages.add(
              _Message(
                1,
                backspacesCounter > 0
                    ? _messageBuffer.substring(
                        0, _messageBuffer.length - backspacesCounter)
                    : _messageBuffer + dataString.substring(0, index),
              ),
            );
            _messageBuffer = dataString.substring(index);
            _length = messages.length - 1;

            if (_controleTela == 1) {
              var valores = messages[_length].text.trim().split(",");
              _estado = valores[0];
              _temperatura = valores[1];
              _umidade = valores[2];
            } else {
              _estado = "0";
              _temperatura = "0";
              _umidade = "0";
            }
          });
        } else {
          _messageBuffer = (backspacesCounter > 0
              ? _messageBuffer.substring(
                  0, _messageBuffer.length - backspacesCounter)
              : _messageBuffer + dataString);
        }
        print("Valor da condição é: $_condicao");
        // print("Imprimindo lista de messages:");
        // int tamanho = messages.length;
        // print(messages[tamanho - 1].text.trim());
      }).onDone(() {
        print('Disconnected by remote request');
      });
    } catch (exception) {
      //chamar uma tela informando para encerrar o aplicativo e voltar novamente pq esta dando erro
      Navigator.push(context,
          MaterialPageRoute(builder: (BuildContext context) => PaginaErro()));
      print('Cannot connect, exception occured');
    }
  }

  void _capturaVelocidade() async {
    var controleVelocidade;
    controleVelocidade =
        userAccelerometerEvents.listen((UserAccelerometerEvent event) {
      //captura velocidade sem gravidade
      double newVelocity = sqrt(event.x * event.x +
          event.y * event.y +
          event.z * event.z); //raiz quadrada de tds val em x, y e z ao quadrado

      if ((newVelocity - velocity).abs() < 1) {
        //return valor absoluto s/ sinal
        // print((newVelocity - velocity).abs());
        return;
      }

      setState(() {
        velocity = newVelocity;

        if (velocity > highestVelocity) {
          highestVelocity = velocity;
        }
        print(
            "A velocidade atual é: $velocity e o contador está em: $contador");

        contador++;

        //logica de renderização de notificações na tela
        if (velocity < 2 && _condicao == 1) {
          _controleTela = 0;
        } else if (velocity >= 2) {
          _controleTela = 1;
          _condicao = 0;
        } else if (velocity < 0.7 && _condicao == 0) {
          controleVelocidade.cancel(); //cancela exec do listen \o/
          connection.close();
          Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (BuildContext context) =>
                      PaginaPergunta(widget.server)));
        }
        //código para poder modificar elementos da tela de notificação
        // if(velocity > 0){
        //    _controleTela = 1;
        //   _condicao = 0;
        // }
      });
    });
  }

  @override
  void initState() {
    super.initState();
    _condicao = widget.condicaoNotificacao;
    _recebendoDados();
    _capturaVelocidade();
  }

  @override
  Widget build(BuildContext context) {
    return TelaMensagem(_estado, _temperatura,
        _umidade); //estado, temperatura, umidade, mensagem
  }
}
