using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class screenShot : MonoBehaviour
{

    private string _caminho;

    void Start()
    {
        _caminho = Application.dataPath + "/capturas/";
        if(!Directory.Exists(_caminho)){
            Directory.CreateDirectory(_caminho);
        }
    }

    void Update()
    {
        //tecla responsavel pelo print da tela
        if(Input.GetKeyDown(KeyCode.P)){
            string nomeImagem = _caminho + "ola" + ".png";
            ScreenCapture.CaptureScreenshot(nomeImagem);
        }
    }
}
