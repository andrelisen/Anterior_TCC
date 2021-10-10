import 'package:flutter/material.dart';
import 'pagNome.dart';

void main() {
  runApp(PagPrincipal());
}

class PagPrincipal extends StatelessWidget { 
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        brightness: Brightness.light,
        primaryColor: Colors.green[800],
      ),
      home: PaginaNome(), 
      debugShowCheckedModeBanner: false,
    );
  }
}
