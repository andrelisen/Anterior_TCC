using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Player : MonoBehaviour
{
    public Transform aimTarget; //alvo para onde a bolinha será lançada para o lado do bot
    
    float speed = 15.0f; //velocidade da raquete que será multiplicada pela posição
    float force = 15; //15
    
    bool hitting;

    public Transform ball;
    //public Rigidbody playerRb;

    Vector3 aimTargetPosition;

    //posição aleatoria de rebate da bolinha 
    public Transform[] targets;

    //Comunicação serial
    // SerialPort porta;

    public static bool flagDificuldade;

    public static int numAcertos;

    public static float acelMedia;
    public static int numLeitura;
    public static float tempoDecorrido;

    int testeSBlue;
    void Start()
    {
        //playerRb = this.GetComponent<Rigidbody>();
        aimTargetPosition = aimTarget.position;
        // porta = new SerialPort("/dev/ttyACM0", 115200);
        // porta.Open();
        // porta.ReadTimeout = -1; //InfiniteTimeout = -1
        // porta.DiscardInBuffer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
            //capturar posição se pra frente, pra trás, pra direita ou pra esquerda
            float h = Input.GetAxisRaw("Horizontal"); //direita = 1 esquerda = -1
            float v = Input.GetAxisRaw("Vertical");

            if(h != 0 || v != 0){ 
            //movimenta avatar
                //time.deltatime evita alta taxa de atualização de quadros
                // transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); //se não colocar uma velocidade o movimento do player é muito rapidamente
                    // playerRb.velocity = new Vector3(0, 0, h) * speed;
                    if(h == 1f){
                        transform.position += new Vector3(0, 0, 1 * speed * Time.deltaTime);
                    }else{
                        transform.position += new Vector3(0, 0, -1 * speed * Time.deltaTime);
                    }
            }
                    
    }

    //função para mover player
    void moveAvatar(int direcao){
        if(direcao == 1){
            // transform.Translate(-Vector2.right * velocidade * Time.deltaTime, Space.World);
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if(direcao == 0){
            // transform.Translate(Vector2.right * velocidade * Time.deltaTime, Space.World);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }

    //função para retornar aleatoriamente uma posição p/ rebate da bolinha pelo player - 3 opções por enquanto
    Vector3 PickTarget(){
        int randomValue =  Random.Range(0, targets.Length);
        return targets[randomValue].position;
    }

    //função para tratar colisões com a raquete -> bola + raquete 
    // private void OnCollisionEnter(Collision other){
    private void OnTriggerEnter(Collider other) {
        //verifica se a colisão foi com a bola
        if(other.CompareTag("Ball")){
            numAcertos++;
            Vector3 dir;
            //movimentando target usando teclado
            if(flagDificuldade == false){
                dir = aimTarget.position - transform.position; //pega a posição do alvo para rebater a bolinha - posição atual da raquete
            }else{
                //movimentando target usando aleatoriedade
                dir = PickTarget() - transform.position; //pega a posição do alvo para rebater a bolinha - posição atual da raquete
            }
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0); //bolinha

            Vector3 ballDir = ball.position - transform.position;
            aimTarget.position = aimTargetPosition;

            ball.GetComponent<Ball>().hitter = "player"; //modificando uma var. publica da class ball
            ball.GetComponent<Ball>().playing = true;
        }
    }

    
    //seta posição quando erra jogada
    // public void Reset(){
    //     if(servedRight){
    //         transform.position = serveLeft.position;
    //     }else{
    //         transform.position = serveRight.position;
    //     }

    //     servedRight = !servedRight;

    // }

}
