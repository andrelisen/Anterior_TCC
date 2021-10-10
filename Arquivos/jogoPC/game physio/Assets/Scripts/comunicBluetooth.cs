using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class comunicBluetooth : MonoBehaviour
{
    //Comunicação serial
    public static SerialPort porta;
    private bool flagInit;
    public static int modoJogo;

    public GameObject loadingScreen;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("sceneHandShake")){
            porta = new SerialPort("/dev/ttyACM1", 115200);
            porta.Open();
            porta.ReadTimeout = -1; //InfiniteTimeout = -1
            porta.DiscardInBuffer();
            //porta.DiscardOutBuffer();
            flagInit = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(porta.IsOpen){
            try{

                string leitura = porta.ReadLine();
                //calcula e verifica quantidade de caracteres
                int tamanhoLeitura = leitura.Length;

                if(flagInit == false){
                    Debug.Log("Enviando mensagem para o Arduino");
                    porta.Write("1");
                    flagInit = true;
                }   

                //if(tamanhoLeitura == 4){
                //    Debug.Log("... \n");
                //}

                if(tamanhoLeitura == 6 || tamanhoLeitura == 7 ){
                    // porta.DiscardInBuffer();
                    //GetComponent<barraCarga>().LoadLevel(7);
                    Debug.Log("Carregamento da cena");
                    LoadLevel(7);
                    //Debug.Log("Feito \n");
                    //UnityEngine.SceneManagement.SceneManager.LoadScene("sceneJogo");
                }
            }catch(System.Exception){
                    throw;
            }
        }        
    }

    public void LoadLevel(int sceneName){
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(int sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        loadingScreen.SetActive(true);

        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }

    }
}
