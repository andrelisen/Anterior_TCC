using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    // Animator animator;
    public Transform ball;
    public Transform aimTarget;

    Vector3 targetPosition;

    //modo sem bluetooth
    // float speed = 9.5f; //25
    // float force = 10f; //15
    
    //modo com bluetooth
    public static float speed;
    public static float force; //15

    public Transform[] targets;

    public static bool flagDificuldade;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //mover em direção a alvo aleatório
    void Move(){
        targetPosition.z = ball.position.z;
        //movimenta bot entre posição atual e targetPosition(no caso é a pos da ball) com a velocidade especificada
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    //função para retornar aleatoriamente uma posição p/ rebate da bolinha pelo bot - 3 opções por enquanto
    Vector3 PickTarget(){
        int randomValue =  Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }

    private void OnTriggerEnter(Collider other){
        //verifica se a colisão foi com a bola
        if(other.CompareTag("Ball")){
            Vector3 dir;
            if(flagDificuldade == false){
                dir = aimTarget.position - transform.position;
            }else{
                dir = PickTarget() - transform.position; //pega a posição do alvo para rebater a bolinha - posição atual da raquete
             }
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0);
            Vector3 ballDir = ball.position - transform.position;
            ball.GetComponent<Ball>().hitter = "bot";
            ball.GetComponent<Ball>().playing = true;
        }
    }
    
}
