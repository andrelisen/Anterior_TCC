using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class configCalibragem : MonoBehaviour
{
    //Cria variável para a Comunicação serial
    public static SerialPort porta;

    void Start()
    {
        //Cria porta e abre 
        porta = new SerialPort("/dev/ttyACM0", 115200);
        porta.Open();
        porta.ReadTimeout = -1; //InfiniteTimeout = -1
    }

    void Update()
    {
        if(porta.IsOpen){
            try{
                //Verifica se está sendo recebido dados 
                if(porta.BytesToRead == 0){ //Não está sendo recebido dados no buffer
                    Debug.Log(porta.BytesToRead);
                    // Debug.Log("Sem recebimento de dados!");
                }else{ //Iniciou o recebimento de dados no buffer
                    string lePorta = porta.ReadLine();
                    Debug.Log(lePorta);
                }
            }catch(System.Exception){
                throw;
            }
        }
    }

    public void Calibragem(int extremo){
        if(porta.IsOpen){
            try{
                if(extremo == 0){
                    //direita
                    porta.Write("0");
                }else if(extremo == 1){
                    //esquerda
                    porta.Write("1");
                }
            }catch(System.Exception){
                throw;
            }
        }
    }
}
