using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class atrasoPartida : MonoBehaviour
{

    public GameObject jogador;
    public GameObject adversario;
    public GameObject bolinha;

    public GameObject painelAguarde;
    public GameObject txtTempo;

    IEnumerator Start()
    {
        painelAguarde.SetActive(true);
        jogador.SetActive(false);
        adversario.SetActive(false);
        bolinha.SetActive(false);
        yield return StartCoroutine(AtrasarJogo(5.0F));
        painelAguarde.SetActive(false);
        jogador.SetActive(true);
        adversario.SetActive(true);
        bolinha.SetActive(true);
        modoJogo.startGame = 1;
    }


    IEnumerator AtrasarJogo(float waitTime) {
        int numSeconds = 5;
        int msg = 5;
        for(int i = 5; i >= 0; i--){
            // Debug.Log(i);
            txtTempo.GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        // Debug.Log("5");
        // yield return new WaitForSeconds(1);
        // Debug.Log("4");
        // yield return new WaitForSeconds(1);
        // Debug.Log("3");
        // yield return new WaitForSeconds(1);
        // Debug.Log("2");
        // yield return new WaitForSeconds(1);
        // Debug.Log("1");
        // yield return new WaitForSeconds(1);
    }
}
