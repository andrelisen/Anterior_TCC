using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressSliderGame : MonoBehaviour
{
    //GameObjects para atrasar
    public GameObject jogador;
    public GameObject adversario;
    public GameObject bolinha;

    //Barra de carregamento
    public Slider barra;
    //Canva referente ao carregamento da cena
    public GameObject janelaCarregamento;
    //Canva referente ao placar 
    public GameObject janelaPlacar;
    //GameOBject do texto de tempo restante
    public GameObject txtTempo;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Config. como false o painel do placar do jogo
        janelaPlacar.SetActive(false);
        //Config. como true o painel de carregamento do jogo
        janelaCarregamento.SetActive(true);
        //Config. como false o jogador, bot e bolinha para atrasar inicio da partida
        jogador.SetActive(false);
        adversario.SetActive(false);
        bolinha.SetActive(false);
        //Chama a função de "atraso"
        yield return StartCoroutine(AtrasarInicio(5.0F));
        //Após a conclusão da rotina, config. como false o painel de carregamento
        janelaCarregamento.SetActive(false);
        //Após a rotina config. como true o painel do placar do jogo
        janelaPlacar.SetActive(true);
        //Após a conclusão da rotina anterior, config. true para o jogador, bot e bolinha
        jogador.SetActive(true);
        adversario.SetActive(true);
        bolinha.SetActive(true);
        controllGame.startGame = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //função para atrasar inicio da partida em 5s
    IEnumerator AtrasarInicio(float waitTime) {
        //for de 1 em 1 seg
        for(int i = 5; i >= 0; i--){
            barra.value += 0.20f;
            txtTempo.GetComponent<Text>().text = "TEMPO RESTANTE: " + i.ToString() + "s";
            yield return new WaitForSeconds(1);
        }
    }
}
