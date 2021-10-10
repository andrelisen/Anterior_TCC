import 'package:flutter/material.dart';
import 'package:path_provider/path_provider.dart';
import 'dart:io';
import 'dart:convert';

class VisualizarLogs extends StatefulWidget {
  @override
  _VisualizarLogsState createState() => _VisualizarLogsState();
}

class _VisualizarLogsState extends State<VisualizarLogs> {
  File jsonFile;
  Directory dir;
  String fileName = "myJson.json"; //nome do arquivo
  bool fileExists = false;
  // var fileContent = new Map(); //Map usado p/ capturar arquivo antes de decode
  Map<String, dynamic> fileContent;

  var myVetor = new Map();
  final List<int> colorCodes = <int>[50, 100];

  int tamanhoLista;

  @override
  void initState() {
    super.initState();

    //captura diretorio p/ salvar arquivo - automatic
    getApplicationDocumentsDirectory().then((Directory directory) {
      dir = directory;
      jsonFile = File(dir.path + "/" + fileName);
      fileExists = jsonFile.existsSync(); //return se existe arq no directory

      if (fileExists) {
        setState(() {
          fileContent = json.decode(jsonFile.readAsStringSync());
          if (fileContent.isEmpty) {
            tamanhoLista = 0;
          } else {
            tamanhoLista = fileContent.toString().length;
          }
          print("Tamanho = $tamanhoLista");
        });

        fileContent.forEach((key, value) {
          value.forEach((chave, valor) {
            Map<String, dynamic> aux = {chave: valor};
            myVetor.addAll(aux);
          });
        });
      }
    });
  }

  void apagarRegistros() {

    fileContent.clear();
    jsonFile.writeAsStringSync(json.encode(fileContent));

    setState(() {
      fileContent = json.decode(jsonFile.readAsStringSync());
      if (fileContent.isEmpty) {
        tamanhoLista = 0;
      } else {
        tamanhoLista = fileContent.toString().length;
      }
      print("Tamanho = $tamanhoLista");
    });

    
  }

  Widget selecionaList() {
    List<Widget> array = new List<Widget>();
    myVetor.forEach((key, value) {
      print("$key = $value");
      // array.add(Text("$key = $value \n", style: TextStyle(color: Colors.green),));
      array.add(ListTile(title: Text("$key"), subtitle: Text("$value")));
    });
    return new Column(
      children: array,
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Dados das viagens'),
        centerTitle: true,
      ),
      body: Column(
        children: [
          Container(
            alignment: Alignment.topLeft,
            child: IconButton(
              icon: Icon(
                Icons.delete,
                color: Colors.green[800],
              ),
              onPressed: () {
                print("Deletar todos os registros de myJson");
                apagarRegistros();
              },
            ),
          ),
          Expanded(
            child: SizedBox(
              height: 200,
              child: new ListView.builder(
                padding: const EdgeInsets.all(8),
                itemCount: tamanhoLista,
                itemBuilder: (BuildContext context, int index) {
                  return Card(
                    color: Colors.green[50],
                    child: Column(
                      children: [
                        selecionaList(),
                      ],
                    ),
                  );
                },
              ),
            ),
          ),
        ],
      ),
    );
  }
}

//Funciona o card corretamente
//  ListView.builder(
//         padding: const EdgeInsets.all(8),
//         itemCount: fileContent.length,
//         itemBuilder: (BuildContext context, int index) {
//           return Card(
//             color: Colors.green[50],
//             child: Column(
//               children: [
//                 selecionaList(),
//               ],
//             ),
//           );
//         },
//       ),
