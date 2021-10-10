using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class coletaDadosPaciente : MonoBehaviour
{
    //GameObject do paciente
    public GameObject nomePaciente;
    public GameObject idade;
    //Group para capturar o nivel de amputação do paciente
    public ToggleGroup nivelAmputacao;
    // public GameObject nivelAmputacao;
    //Group para capturar o sexo do paciente
    public ToggleGroup escolheSexo;

    //Função para salvar os dados do paciente 
    public void SalvarDadosPaciente(){
        coletaDadosFisicos.opcao = 1;
        dadosJogo.nomePaciente = nomePaciente.GetComponent<Text>().text;
        dadosJogo.idade = idade.GetComponent<Text>().text;

        //Verifica qual opção de amputação foi selecionada
        Toggle amputacoes = nivelAmputacao.ActiveToggles().FirstOrDefault();
        dadosJogo.nivelAmputacao = amputacoes.GetComponentInChildren<Text>().text;

        //Verifica qual opção de sexo foi selecionada
        Toggle opcoes = escolheSexo.ActiveToggles().FirstOrDefault();
        // Debug.Log("Opção:");
        // Debug.Log(opcoes.GetComponentInChildren<Text>().text);
        dadosJogo.sexo = opcoes.GetComponentInChildren<Text>().text;
    }
}
