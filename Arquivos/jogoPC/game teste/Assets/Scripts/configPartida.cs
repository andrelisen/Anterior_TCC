using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configPartida : MonoBehaviour
{
    //GameObject para modo tempo
    public GameObject modoTempo;
    public GameObject inputTempo;
    //GameObject para modo niveis
    public GameObject modoNiveis;
    //GameObject para selecionar configuração
    public GameObject modoConfiguracao;
    //variaveis de configuracao de jogo
    public static int tempo;
    //função para verificar qual painel mostrar na tela
    //a partir da opcao de configuração da partida
    public void renderizaPaineisTela(int opcao){
        if(opcao == 1){
            modoConfiguracao.SetActive(false);
            modoTempo.SetActive(true);
        }else if(opcao == 2){
            modoConfiguracao.SetActive(false);
            modoNiveis.SetActive(true);
        }
    }

    //função para conf. da partida por tempo setando a quantidade em minutos e o modo do jogo
    public void configuracaoTempo(){
        string tempoLeitura = inputTempo.GetComponent<Text>().text;
        tempo = int.Parse(tempoLeitura);
        controllGame.modalidadeJogo = 1;
        carregaCena();
    }

    //função para conf. qual o nivel da partida
    public void configuracaoNiveis(int modalidade){
        controllGame.modalidadeJogo = modalidade;
        carregaCena();
    }

    //função para carregar a cena do jogo logo após a conclusão da configuração
    public void carregaCena(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneJogo");
    }

}
