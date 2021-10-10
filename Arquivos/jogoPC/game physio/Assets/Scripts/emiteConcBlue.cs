using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class emiteConcBlue : MonoBehaviour
{

    public GameObject txtPlayer;
    public GameObject txtBot;
    public GameObject txtNumAcertos;
    public GameObject txtNumErros;
    public GameObject txtVelMedia;
    public GameObject txtTempoDecorrido;

    bool flagSalvarDados;

    string numAcertos, numErros, velMedia, tempo;

    void Start()
    {
        
    }

    public void CreateText(){

        //Path of the file
        string path = Application.dataPath + "/Log.txt";
        //Create file if doesn't exist
        if(!File.Exists(path)){
            File.WriteAllText(path, "Logs TennisGame Physio \n\n");
        }
        //Add some to text to it
        string logger = "Log date:" + System.DateTime.Now + "\n";
        string dados = "N. de acertos: " + numAcertos + " N. erros: " + numErros + " Velocidade média: " + velMedia + " Tempo decorrido: " + tempo + "\n";
        string escrever = logger + dados;
        File.AppendAllText(path, escrever);
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneDadosFisicos");
    }

    void Update()
    {
        txtPlayer.GetComponent<Text>().text = (Ball.playerScore).ToString(); 
        txtBot.GetComponent<Text>().text = (Ball.botScore).ToString(); 
        txtNumAcertos.GetComponent<Text>().text = "Nº DE ACERTOS: " + (Player.numAcertos).ToString(); 
        txtNumErros.GetComponent<Text>().text = "Nº DE ERROS: " + (Ball.numErros).ToString(); 

        float aceleracaoMedia = Player.acelMedia / Player.numLeitura;
        float velocidade = aceleracaoMedia * Player.tempoDecorrido;
        txtVelMedia.GetComponent<Text>().text = "VELOCIDADE MÉDIA: " + velocidade.ToString();

        txtTempoDecorrido.GetComponent<Text>().text = "TEMPO DECORRIDO: " + (Player.tempoDecorrido).ToString();
        
        numAcertos = (Player.numAcertos).ToString();
        numErros = (Ball.numErros).ToString(); 
        velMedia = velocidade.ToString();
        tempo = (Player.tempoDecorrido).ToString();
    }
}
