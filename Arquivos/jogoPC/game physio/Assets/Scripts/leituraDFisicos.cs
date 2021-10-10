using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class leituraDFisicos : MonoBehaviour
{

    public GameObject pressaoArt;
    public GameObject batCard;
    public GameObject oxig;
    public GameObject obs;

    public void CreateText(string pressaoArterial, string batimentosCard, string oxigenacao, string observacoes){

        //Path of the file
        string path = Application.dataPath + "/Log.txt";
        //Create file if doesn't exist
        if(!File.Exists(path)){
            File.WriteAllText(path, "Logs TennisGame Physio \n\n");
        }
        //Add some to text to it
        string logger = "Log date:" + System.DateTime.Now + "\n";
        string dados = "Pressão Arterial: " + pressaoArterial + " Batimentos Cardíacos: " + batimentosCard + " Oxigenação: " + oxigenacao + " Observações: " + observacoes + "\n";
        string escrever = logger + dados;
        File.AppendAllText(path, escrever);
        RenderizaCena();
    }

    public void lerDados(){
        string pressaoArterial = pressaoArt.GetComponent<Text>().text;
        string batimentosCard = batCard.GetComponent<Text>().text;
        string oxigenacao = oxig.GetComponent<Text>().text;
        string observacoes = obs.GetComponent<Text>().text;
        CreateText(pressaoArterial, batimentosCard, oxigenacao, observacoes);
    }

    public void RenderizaCena(){
            UnityEngine.SceneManagement.SceneManager.LoadScene("sceneSelectFase"); //carrega uma nova cena - coloca o nome da cena entre aspas
    }
}
