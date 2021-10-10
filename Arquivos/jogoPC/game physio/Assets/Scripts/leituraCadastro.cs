using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class leituraCadastro : MonoBehaviour
{

    //Leitura do nome do fisioterapeuta e dos dados do paciente - guarda em um arquivo txt

    public GameObject nomeFisioterapeuta;
    public GameObject nomePaciente;
    public GameObject nivelAmputacao;
    public GameObject inpidade;
    public GameObject inpSexo;
    
    public void CreateText(string nomeF, string nomeP, string nivelAmp, string idade, string sexo){

        //Path of the file
        string path = Application.dataPath + "/Log.txt";
        //Create file if doesn't exist
        if(!File.Exists(path)){
            File.WriteAllText(path, "Logs TennisGame Physio \n\n");
        }
        //Add some to text to it
        string logger = "Log date:" + System.DateTime.Now + "\n";
        string dados = "Fisioterapeuta: " + nomeF + " Paciente: " + nomeP + " Nível Amputação: " + nivelAmp + " Idade: " + idade + " Sexo: " + sexo + "\n";
        string escrever = logger + dados;
        File.AppendAllText(path, escrever);
        RenderizaCena();
    }

    public void lerDados(){
        string nomeF = nomeFisioterapeuta.GetComponent<Text>().text;
        string nomeP = nomePaciente.GetComponent<Text>().text;
        string nivelAmp = nivelAmputacao.GetComponent<Text>().text;
        string idade = inpidade.GetComponent<Text>().text;
        string sexo = inpSexo.GetComponent<Text>().text;
        CreateText(nomeF, nomeP, nivelAmp, idade, sexo);
    }

    public void RenderizaCena(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneDadosFisicos"); //carrega uma nova cena - coloca o nome da cena entre aspas
    }
}
