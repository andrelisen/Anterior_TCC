using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseControll : MonoBehaviour
{

    public void Pause(){
        Time.timeScale = 0;
    }

    public void unPause(){
        Time.timeScale = -1;
    }

    public void RestartGame(){
        SceneManager.LoadScene("SceneJogo");
    }

}
