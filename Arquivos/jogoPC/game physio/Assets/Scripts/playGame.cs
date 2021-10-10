using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class playGame : MonoBehaviour
{
    public GameObject inputTempo;
    public static int tempo;

    public void LeTempo(){
        string tempoLeitura = inputTempo.GetComponent<Text>().text;
        tempo = int.Parse(tempoLeitura);
        modoJogo.modalidadeJogo = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneHandShake");
    }

    public void EscolhaNivel(int valNivel){
        modoJogo.modalidadeJogo = valNivel;
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneHandShake");
    }
}
