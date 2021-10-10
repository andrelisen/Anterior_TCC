import 'package:flutter/material.dart';
import 'package:proj_controle/salvaDados.dart';

import 'pagListaDispositivos.dart';

class PaginaSelectConexao extends StatelessWidget {
  final String nome;

  PaginaSelectConexao(this.nome);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('AgroMobile - Controle de carga'),
        centerTitle: true,
        automaticallyImplyLeading: false,
      ),
      body: ListView(
        children: [
          Container(
            alignment: Alignment.center,
            padding: const EdgeInsets.fromLTRB(
                0, 45, 0, 0), //left, top, right, bottom)
            child: Column(
              children: [
                SizedBox(
                  width: 250,
                  height: 150,
                  child: Image.asset('imagens/LogoAplicativo.png'),
                ),
              ],
            ),
          ),
          Container(
            alignment: Alignment.center,
            padding: const EdgeInsets.fromLTRB(
                0, 40, 0, 0), //left, top, right, bottom)
            child: Text(
              'Olá, $nome!',
              style: TextStyle(fontSize: 26, color: Colors.green[900]),
            ),
          ),
          Container(
            alignment: Alignment.center,
            padding: const EdgeInsets.fromLTRB(
                0, 75, 0, 0), //left, top, right, bottom)
            child: SizedBox(
              // width: 180,
              // height: 100,
              child: FlatButton(
                color: Colors.green[800],
                textColor: Colors.white,
                onPressed: () {
                  // print('ui! fui clicado!');
                  print('Antes de selecionar modulo, o valor de MAP é:');
                  print(dadosLog);
                  Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (BuildContext context) =>
                              PaginaLista(nome)));
                },
                child: Text('REALIZAR CONEXÃO COM MÓDULO',
                    style: TextStyle(fontSize: 14)),
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
      ),
    );
  }
}
