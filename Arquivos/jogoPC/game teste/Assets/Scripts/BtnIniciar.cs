using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnIniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderizaCena(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneCadastro"); //carrega uma nova cena - coloca o nome da cena entre aspas
    }
}
