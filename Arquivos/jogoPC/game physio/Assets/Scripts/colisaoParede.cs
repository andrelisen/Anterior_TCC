using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisaoParede : MonoBehaviour
{
    private void OnCollisionEnter(Collision colisor){
        if(colisor.transform.CompareTag("Player")){
            Debug.Log("Atingiu a parede");
        }
    }
}
