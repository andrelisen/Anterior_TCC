import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'package:proj_controle/notificacaoTela.dart';
import 'package:proj_controle/salvaDados.dart';

class PaginaCarga extends StatefulWidget {
  final BluetoothDevice server;
  const PaginaCarga(this.server);
  //if condicaoNotificacao=1 venho do inicio viagem, senáo venho do detectaVelocidade quando detectou uma parada no caminhao

  @override
  _PaginaCargaState createState() => _PaginaCargaState();
}

class _PaginaCargaState extends State<PaginaCarga> {
  TextEditingController totalController = new TextEditingController();
  TextEditingController femeasController = new TextEditingController();
  TextEditingController bezerrosController = new TextEditingController();
  TextEditingController machosController = new TextEditingController();
  
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('AgroMobile - Controle de carga'),
          centerTitle: true,
          automaticallyImplyLeading: false, //para sumir o botão de voltar
        ),
        body: ListView(
          children: [
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 0, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 150,
                child: Image.asset('imagens/LogoAplicativo.png'),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 25, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 300,
                height: 45,
                child: TextField(
                  controller: femeasController,
                  keyboardType: TextInputType.number,
                  decoration: InputDecoration(
                    labelText: "Quantidade de fêmeas",
                    fillColor: Colors.white,
                    border: new OutlineInputBorder(
                      borderRadius: new BorderRadius.circular(25.0),
                      borderSide: new BorderSide(),
                    ),
                  ),
                  style: TextStyle(fontSize: 16),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 300,
                height: 45,
                child: TextField(
                  controller: machosController,
                  keyboardType: TextInputType.number,
                  decoration: InputDecoration(
                    labelText: "Quantidade de machos",
                    fillColor: Colors.white,
                    border: new OutlineInputBorder(
                      borderRadius: new BorderRadius.circular(25.0),
                      borderSide: new BorderSide(),
                    ),
                  ),
                  style: TextStyle(fontSize: 16),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 300,
                height: 45,
                child: TextField(
                  controller: bezerrosController,
                  keyboardType: TextInputType.number,
                  decoration: InputDecoration(
                    labelText: "Quantidade de bezerros",
                    fillColor: Colors.white,
                    border: new OutlineInputBorder(
                      borderRadius: new BorderRadius.circular(25.0),
                      borderSide: new BorderSide(),
                    ),
                  ),
                  style: TextStyle(fontSize: 16),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 300,
                height: 45,
                child: TextField(
                  controller: totalController,
                  keyboardType: TextInputType.number,
                  decoration: InputDecoration(
                    labelText: "Quantidade total",
                    fillColor: Colors.white,
                    border: new OutlineInputBorder(
                      borderRadius: new BorderRadius.circular(25.0),
                      borderSide: new BorderSide(),
                    ),
                  ),
                  style: TextStyle(fontSize: 16),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 275,
                height: 45,
                child: FlatButton(
                  // color: Colors.white,
                  textColor: Colors.green[800],
                  onPressed: () {
                    CapturarDados dadosAnimais = new CapturarDados();
                    dadosAnimais.quantidadeCarga(0, 0, 0, 0, 0);
                    dadosAnimais.capturarLocalizacaoParada(3);

                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (BuildContext context) => NotificacoesTela(
                                server: widget.server,
                                condicaoNotificacao: 1)));
                  },
                  child: Text('CARGA DESCONHECIDA',
                      style: TextStyle(fontSize: 16)),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 180,
                height: 45,
                child: RaisedButton(
                  color: Colors.green[800],
                  textColor: Colors.white,
                  onPressed: () {
                    print("Valor capturado do input numero de femeas = " +
                        femeasController.text);
                    print("Valor capturado do input numero de machos = " +
                        machosController.text);
                    print("Valor capturado do input numero de bezerros = " +
                        bezerrosController.text);
                    print("Valor capturado do input numero total = " +
                        totalController.text);
                    //Retorna para a tela de inserir carga até q o caminhao volte a andar
                    // if (femeasController.text == '' &&
                    //     machosController.text == '' &&
                    //     totalController.text != '') {
                    //   print('Existe apenas a quantidade total!');
                    // }
                    // if (femeasController.text != '' &&
                    //     machosController.text != '' &&
                    //     totalController.text == '') {
                    //   print('Existe apenas a quantidade de machos e femeas!');
                    // }
                    if (femeasController.text != '' ||
                        machosController.text != '' || 
                        bezerrosController.text != '' ||
                        totalController.text != '') {
                      // int numeroMachos = int.parse(machosController.text);
                      // int numeroFemeas = int.parse(femeasController.text);
                      // int numeroTotal = int.parse(totalController.text);

                      var numeroMachos;
                      var numeroFemeas;
                      var numeroBezerros;
                      var numeroTotal;

                      if (machosController.text == '') {
                        numeroMachos = 0;
                      } else {
                        // numeroMachos = int.parse(machosController.text);
                        numeroMachos = int.parse(machosController.text);
                      }
                      if (femeasController.text == '') {
                        numeroFemeas = 0;
                      } else {
                        numeroFemeas = int.parse(femeasController.text);
                      }
                      if (bezerrosController.text == '') {
                        numeroBezerros = 0;
                      } else {
                        numeroBezerros = int.parse(bezerrosController.text);
                      }
                      if (totalController.text == '') {
                        numeroTotal = 0;
                      } else {
                        numeroTotal = int.parse(totalController.text);
                      }

                      print(
                          "Valores capturados são: fêmeas = $numeroFemeas, machos = $numeroMachos, bezerros = $numeroBezerros e total de $numeroTotal");
                      CapturarDados dadosAnimais = new CapturarDados();
                      dadosAnimais.quantidadeCarga(
                          1, numeroFemeas, numeroMachos, numeroBezerros, numeroTotal);
                      dadosAnimais.capturarLocalizacaoParada(3);
                      Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (BuildContext context) =>
                                  NotificacoesTela(
                                      server: widget.server,
                                      condicaoNotificacao: 1)));
                    }
                  },
                  child: Text('INSERIR', style: TextStyle(fontSize: 16)),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 45, 0, 0), //left, top, right, bottom)
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
