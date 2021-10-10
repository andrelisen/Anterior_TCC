using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configModoJogo : MonoBehaviour
{
    public int modalidade;
    // Start is called before the first frame update
    public void SelecionaModo(int flag){
        if(flag == 1){
            //modalidade por tempo
            UnityEngine.SceneManagement.SceneManager.LoadScene("sceneModoTimer");
        }else if(flag == 2){
            //modalidade por níveis
            UnityEngine.SceneManagement.SceneManager.LoadScene("sceneModoNiveis");
        }
    }
}
