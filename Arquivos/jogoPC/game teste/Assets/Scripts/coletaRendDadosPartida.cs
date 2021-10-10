using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coletaRendDadosPartida : MonoBehaviour
{
    //GameObject placares
    public GameObject placarPlayer;
    public GameObject placarBot;
    //GameObject referente ao ganhador colocando uma estrela em cima do placar vencedor
    public GameObject indicadorPlayer;
    public GameObject indicadorBot;
    //Gameobject referente a n. de acertos, erros, velocidade media, tempo, distancia, aceleracao
    public GameObject numAcertos;
    public GameObject numErros;
    public GameObject velocidadeMedia;
    public GameObject tempo;
    public GameObject distancia;
    public GameObject aceleracaoMedia;
    void Start()
    {
        
        placarPlayer.GetComponent<Text>().text = (Ball.playerScore).ToString();
        placarBot.GetComponent<Text>().text = (Ball.botScore).ToString();

        if(Ball.botScore > Ball.playerScore){
            indicadorBot.SetActive(true);
        }else if(Ball.playerScore > Ball.botScore){
            indicadorPlayer.SetActive(true);
        }

        numAcertos.GetComponent<Text>().text = (Player.numAcertos).ToString();
        numErros.GetComponent<Text>().text = (Ball.numErros).ToString();

        velocidadeMedia.GetComponent<Text>().text = "C";
        tempo.GetComponent<Text>().text = (controllGame.tempoTotalPartida).ToString();
        distancia.GetComponent<Text>().text = "C";
        aceleracaoMedia.GetComponent<Text>().text = "C";

    }

    // Update is called once per frame
    void Update()
    {
        

    }   
}
