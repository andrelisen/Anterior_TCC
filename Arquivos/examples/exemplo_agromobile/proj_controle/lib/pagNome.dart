import 'package:flutter/material.dart';
import 'package:proj_controle/pagLog.dart';
import 'pagSelecionaConexao.dart';
import 'package:flutter/services.dart';
import 'salvaDados.dart';
import 'package:imei_plugin/imei_plugin.dart';

class PaginaNome extends StatefulWidget {
  @override
  _PaginaNomeState createState() => _PaginaNomeState();
}

class _PaginaNomeState extends State<PaginaNome> {
  TextEditingController nomeController = new TextEditingController();
  String _platformImei = 'Desconhecido';

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
              alignment: Alignment.topRight,
              padding: const EdgeInsets.fromLTRB(
                  0, 5, 7, 0), //left, top, right, bottom)
              child: IconButton(
                tooltip: 'Visualizar dados de viagens',
                icon: Icon(
                  Icons.library_books,
                  color: Colors.green[800],
                ),
                onPressed: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (BuildContext context) => VisualizarLogs()));
                },
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 10, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 150,
                child: Image.asset('imagens/LogoAplicativo.png'),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 90, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 300,
                height: 45,
                child: TextField(
                  controller: nomeController,
                  keyboardType: TextInputType.name,
                  decoration: InputDecoration(
                    labelText: "Digite seu nome *",
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
                  0, 10, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 90,
                height: 45,
                child: RaisedButton(
                  color: Colors.green[800],
                  textColor: Colors.white,
                  onPressed: () async {
                    String nome = nomeController.text;
                    String platformImei; //onde salva IMEI

                    if (nome != '') {
                      try {
                        platformImei = await ImeiPlugin.getImei(
                            shouldShowRequestPermissionRationale: false);
                        List<String> multiImei =
                            await ImeiPlugin.getImeiMulti();
                        print(multiImei);
                      } on PlatformException {
                        platformImei = 'Desconhecido';
                      }

                      if (!mounted) return;

                      setState(() {
                        _platformImei = platformImei;
                      });

                      Map<String, dynamic> dadosMotorista = {
                        'nome': nome,
                        'numeroIMEI': _platformImei
                      };
                      // print(dadosMotorista);
                      dadosLog.addAll(dadosMotorista);
                      // dadosLog
                      //     .addAll({'nome': nome, 'numeroIMEI': _platformImei});

                      // CapturarDados capturaLocalizacao = new CapturarDados();
                      // capturaLocalizacao.capturarLocalizacaoParada(1);

                      Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (BuildContext context) =>
                                  PaginaSelectConexao(nome)));
                    }
                  },
                  child: Text('OK', style: TextStyle(fontSize: 20)),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 75, 0, 0), //left, top, right, bottom)
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
