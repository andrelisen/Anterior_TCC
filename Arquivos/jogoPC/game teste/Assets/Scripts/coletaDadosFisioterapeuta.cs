using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coletaDadosFisioterapeuta : MonoBehaviour
{
    //GameObject do fisioterapeuta
    public GameObject nomeFisioterapeuta;
    
    //Função para salvar dados do fisioterapeuta
    public void SalvarFisioterapeuta(){
        dadosJogo.nomeFisioterapeuta = nomeFisioterapeuta.GetComponent<Text>().text;
    }

}
