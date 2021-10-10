import 'dart:io';

import 'package:flutter/material.dart';

class PaginaErro extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.green[100],
      body: Column(
        children: [
          Container(
            child: Icon(
              Icons.report_problem,
              size: 100,
              color: Colors.green[400],
            ),
            margin: const EdgeInsets.fromLTRB(
                0, 200, 0, 0), //left, top, right, bottom
            alignment: Alignment.center,
          ),
          Container(
            margin: const EdgeInsets.fromLTRB(
                15, 50, 15, 0), //left, top, right, bottom
            alignment: Alignment.center,
            child: Text(
              'FALHA DE CONEXÃO COM O MÓDULO.',
              style: TextStyle(
                  fontSize: 26,
                  color: Colors.black54,
                  fontWeight: FontWeight.bold),
              textAlign: TextAlign.center,
            ),
          ),
          IconButton(
            alignment: Alignment.center,
            padding: const EdgeInsets.fromLTRB(0, 100, 0, 0),
            icon: Icon(
              Icons.exit_to_app,
              size: 54,
              color: Colors.black87,
            ),
            onPressed: () => exit(0),
          ),
        ],
      ),
    );
  }
}
