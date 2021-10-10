using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controle do jogo
public class controllGame : MonoBehaviour
{
    //Variavel de config. do modo do jogo: 1 - tempo, 2 - fácil, 3- médio, 4-difícil 
    public static int modalidadeJogo; 
    //Flag para controle do início do jogo
    public static int startGame;
    //Calculando o tempo decorrido total da partida
    public static float tempoTotalPartida;
    //variavel responsavel pela coleta do tempo da partida configurado pelo fisioterapeuta
    int tempoPartida;
    //variavel que realiza o calculo da partida durante a execução da configuração de partida por tempo
    float tempoDecorrido;

    void Update()
    {
        //Configuração dos modos de jogo
        if(startGame == 1){
            tempoTotalPartida += Time.deltaTime;
            switch(modalidadeJogo){
                case 1: //tempo
                    Debug.Log("Tempo");
                    tempoPartida = configPartida.tempo; //lê tempo necessario
                    tempoPartida = tempoPartida * 60; //converte tempo em segundos
                    tempoDecorrido += Time.deltaTime; 
                    Player.flagDificuldade = false; //config. partida para ser fácil
                    Bot.flagDificuldade = false; //config. bot para ser fácil
                    Bot.speed = 9.5f;
                    Bot.force = 10f;
                    if(tempoDecorrido >= tempoPartida){
                        Time.timeScale = 0;
                        // comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFimPartida");
                    }
                break;
                case 2: //fácil 
                    //A velocidade do bot é 9.5f, força exercida é 10f e o num. de acertos é 5 acertos(bot ou paciente)
                    Player.flagDificuldade = false;
                    Bot.flagDificuldade = false;
                    Bot.speed = 9.5f;
                    Bot.force = 10f;
                    if(Ball.playerScore == 5 || Ball.botScore == 5){
                        Time.timeScale = 0;
                        // comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFimPartida");
                    }
                break;
                case 3: //médio
                    //A velocidade do bot é 12.5f, força exercida é 12f e o num. de acertos é 7 acertos(bot ou paciente)
                    Player.flagDificuldade = true;
                    Bot.flagDificuldade = true;
                    Bot.speed = 12.5f;
                    Bot.force = 12f;
                    if(Ball.playerScore == 8 || Ball.botScore == 8){
                        Time.timeScale = 0;
                        // comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFimPartida");
                    }
                break;
                case 4: //difícil
                    //A velocidade do bot é 25f, força exercida é 15f e o num. de acertos é 13 acertos(bot ou paciente)
                    //10 acertos
                    Player.flagDificuldade = true;
                    Bot.flagDificuldade = true;
                    Bot.speed = 25f;
                    Bot.force = 15f;
                    if(Ball.playerScore == 13 || Ball.botScore == 13){
                        Time.timeScale = 0;
                        // comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFimPartida");
                    }
                break;
            }
        }
    }
    //função para trocar cena

    //função de salvar os dados em um arquivo txt

    

}
