import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_bluetooth_serial/flutter_bluetooth_serial.dart';
import 'package:path_provider/path_provider.dart';
import 'dart:convert';
import 'pagCarga.dart';
import 'package:proj_controle/salvaDados.dart';

class PaginaPergunta extends StatefulWidget {
  final BluetoothDevice server;
  PaginaPergunta(this.server);

  @override
  _PaginaPerguntaState createState() => _PaginaPerguntaState();
}

class _PaginaPerguntaState extends State<PaginaPergunta> {
  File jsonFile;
  Directory dir;
  String fileName = "myJson.json"; //nome do arquivo
  bool fileExists = false;
  Map<String, dynamic>
      fileContent; //Map usado p/ capturar arquivo antes de decode

  @override
  void initState() {
    super.initState();

    //captura diretorio p/ salvar arquivo - automatic
    getApplicationDocumentsDirectory().then((Directory directory) {
      dir = directory;
      jsonFile = File(dir.path + "/" + fileName);
      fileExists = jsonFile.existsSync(); //return se existe arq no directory

      if (fileExists) {
        this.setState(
            () => fileContent = json.decode(jsonFile.readAsStringSync()));
      }
    });
  }

  //funcao para criar arquivo
  void createFile(
      Map<String, dynamic> content, Directory dir, String fileName) {
    print("Criando o arquivo!");

    File file = File(dir.path + "/" + fileName);
    file.createSync();
    fileExists = true;
    file.writeAsStringSync(json.encode(content));
  }

  void writeToFile() {
    print("Escrevendo no arquivo!");

    int tam;
    if (fileContent == null) {
      tam = 0;
    } else {
      tam = fileContent.length;
    }

    String chave = "#" + tam.toString();
    Map<String, dynamic> content = {chave: dadosLog};

    if (fileExists) {
      print("Arquivo existente");
      Map<String, dynamic> jsonFileContent =
          json.decode(jsonFile.readAsStringSync());
      jsonFileContent.addAll(content);
      print(jsonFileContent);
      jsonFile.writeAsStringSync(json.encode(jsonFileContent));
    } else {
      print("Arquivo não existe!");
      createFile(content, dir, fileName);
    }
    this.setState(() => fileContent = json.decode(jsonFile.readAsStringSync()));
    print(fileContent);
  }

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
                  0, 75, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 45,
                child: RaisedButton(
                  color: Colors.green[800],
                  textColor: Colors.white,
                  onPressed: () {
                    // print('ui! fui clicado!');
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (BuildContext context) =>
                                PaginaCarga(widget.server)));
                  },
                  child: Text('INSERIR CARGA', style: TextStyle(fontSize: 20)),
                ),
              ),
            ),
            Container(
              alignment: Alignment.center,
              padding: const EdgeInsets.fromLTRB(
                  0, 15, 0, 0), //left, top, right, bottom)
              child: SizedBox(
                width: 250,
                height: 45,
                child: RaisedButton(
                  color: Colors.green[800],
                  textColor: Colors.white,
                  onPressed: () {
                    writeToFile();
                    exit(0);
                  },
                  child:
                      Text('FINALIZAR VIAGEM', style: TextStyle(fontSize: 20)),
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
