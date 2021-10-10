using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modoJogo : MonoBehaviour
{

    public static int modalidadeJogo; // 1 - tempo, 2 - fácil, 3- médio, 4-difícil
    public static int startGame;
    
    int tempoPartida;
    float tempoDecorrido;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(startGame == 1){
            switch(modalidadeJogo){
                case 1: //tempo
                    tempoPartida = playGame.tempo;
                    tempoPartida = tempoPartida * 60; //converte em segundos
                    tempoDecorrido += Time.deltaTime;
                    Player.flagDificuldade = false;
                    Bot.flagDificuldade = false;
                    Bot.speed = 9.5f;
                    Bot.force = 10f;
                    if(tempoDecorrido >= tempoPartida){
                        Time.timeScale = 0;
                        comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFinalPartida");
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
                        comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFinalPartida");
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
                        comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFinalPartida");
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
                        comunicBluetooth.porta.Close();
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFinalPartida");
                    }
                break;
            }
        }
    }
}
