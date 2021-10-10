import 'package:geolocator/geolocator.dart';
import 'package:geocoding/geocoding.dart';

var dadosLog = new Map();
// Map<String, dynamic> dadosLog;

class CapturarDados {
  void capturarLocalizacaoParada(int condicao) async {
    DateTime dataHora = new DateTime.now();
    // print('A data e hora no momento da parada é: $dataHora');
    // print('entrei!');
    Position position = await Geolocator.getCurrentPosition();
    // print(position.altitude);
    // print(position.latitude);
    // print(position.longitude);
    List<Placemark> placemarks =
        await placemarkFromCoordinates(position.latitude, position.longitude);
    String endereco = placemarks[0].street +
        ', ' +
        placemarks[0].subLocality +
        ', ' +
        placemarks[0].subThoroughfare +
        '. ' +
        placemarks[0].postalCode +
        ', ' +
        placemarks[0].subAdministrativeArea +
        ', ' +
        placemarks[0].administrativeArea;

    // print('Localização no momento da parada: $endereco');

    if (condicao == 1) {
      //momento que o caminhao parou
      // // Map<String, dynamic> dadosParada = {
      // //   "horarioParada": dataHora.toString(),
      // //   "localizacaoParada": endereco,
      // // };
      // dadosLog.addAll(dadosParada);
      dadosLog.addAll({
        "horarioParada": dataHora.toString(),
        "localizacaoParada": endereco
      });
    }
    if (condicao == 2) {
      //momento que o caminhao andou
      // Map<String, dynamic> dadosArrancada = {
      //   "horarioPartida": dataHora.toString(),
      //   "localizacaoPartida": endereco,
      // };
      // dadosLog.addAll(dadosArrancada);
      dadosLog.addAll({
        "horarioPartida": dataHora.toString(),
        "localizacaoPartida": endereco
      });
    }
    if (condicao == 3) {
      //momento que o caminhao andou
      // Map<String, dynamic> dadosCarregamento = {
      //   "horarioCarregamento": dataHora.toString(),
      //   "localizacaoCarregamento": endereco,
      // };
      // dadosLog.addAll(dadosCarregamento);
      dadosLog.addAll({
        "horarioCarregamento": dataHora.toString(),
        "localizacaoCarregamento": endereco
      });
    }
  }

  void quantidadeCarga(var numero, var femea, var macho, var bezerros, var total) {
    if (numero == 0) {
      //carga desconhecida
      // Map<String, dynamic> dadosAnimais = {
      //   "quantidadeAnimais": 'Quantidade de animais desconhecida',
      //   "femeas": 0,
      //   "machos": 0,
      //   // "bezerros": 0,
      //   "total": 0
      // };
      // dadosLog.addAll(dadosAnimais);
      dadosLog.addAll({
        "quantidadeAnimais": 'Quantidade de animais desconhecida',
        "femeas": 0,
        "machos": 0,
        "bezerros":0,
        "total": 0
      });
    } else {
      //alguma caracteristica da carga é conehcida
      // int soma = femea + macho + bezerro;

      // Map<String, dynamic> dadosAnimais = {
      //   "quantidadeAnimais": 'Quantidade de animais conhecida',
      //   "femeas": femea,
      //   "machos": macho,
      //   // "bezerros": 0,
      //   "total": total
      // };
      // dadosLog.addAll(dadosAnimais);
      dadosLog.addAll({
        "quantidadeAnimais": 'Quantidade de animais conhecida',
        "femeas": femea,
        "machos": macho,
        "bezerros": bezerros,
        "total": total
      });
    }
  }
}
