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
    
    Vector3 aimTargetPosition;


    //posição aleatoria de rebate da bolinha 
    public Transform[] targets;


    //Comunicação serial
    // SerialPort porta;

    [SerializeField] Transform serveRight;
    [SerializeField] Transform serveLeft;

    bool servedRight = true;

    bool flagConexao;
    private float timer = 0.0f;

    public static bool flagDificuldade;

    public static int numAcertos;

    public static float acelMedia;
    public static int numLeitura;
    public static float tempoDecorrido;

    int testeSBlue;

    void Start()
    {
        testeSBlue = 1;
        aimTargetPosition = aimTarget.position;
        // porta = new SerialPort("/dev/ttyACM0", 115200);
        // porta.Open();
        // porta.ReadTimeout = -1; //InfiniteTimeout = -1
        // porta.DiscardInBuffer();
        if(testeSBlue == 0){
            comunicBluetooth.porta.DiscardInBuffer();
            comunicBluetooth.porta.DiscardOutBuffer();
            flagConexao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(testeSBlue == 1){
            //capturar posição se pra frente, pra trás, pra direita ou pra esquerda
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if(h != 0 || v != 0){ 
            //movimenta avatar
                //time.deltatime evita alta taxa de atualização de quadros
                transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime); //se não colocar uma velocidade o movimento do player é muito rapidamente
            }
            
        }else{
            if(comunicBluetooth.porta.IsOpen){
                try{
                    //emite flag para arduino saber que a porta serial ta aberta
                    //arduino verifica se tem dados sendo recebidos via bluetooth
                    //se sim, encaminha
                        //limpa o buffer de entrada anterior
                        //começa a receber os novos dados 
                        //realiza movimento do avatar
                    //se não, envia mensagem de aguardo/vazio
                        //limpa o buffer sempre até arduino emitir aviso de envio de dados
                        //emite mensagem de aguarde para mover seu avatar - na tela do jogo

                        float h = 0;
                        float v = 0;
                        
                        //Debug.Log(porta.ReadByte()); //esse funciona
                        //Debug.Log(porta.ReadChar()); //esse funciona também mas vem como byte
                        //Debug.Log(porta.ReadLine()); //esse funciona e captura toda a linha corretamente \o/
                        //leitura da entrada
                        string leitura = comunicBluetooth.porta.ReadLine();
                        //calcula e verifica quantidade de caracteres
                        int tamanhoLeitura = leitura.Length;
                        tempoDecorrido += Time.deltaTime;


                        if(tamanhoLeitura == 4){
                            Debug.Log("Vazio");
                            comunicBluetooth.porta.DiscardInBuffer();
                            comunicBluetooth.porta.DiscardOutBuffer();
                            h=0;
                            v=0;
                        }else if(tamanhoLeitura == 6 ){
                            numLeitura++;
                            h=1;
                            v=1;
                            if((h != 0 || v != 0) && !hitting){ 
                                moveAvatar(1);
                            }
                        }else if(tamanhoLeitura == 7 ){
                            numLeitura++;
                            h=-1;
                            v=-1;
                            if((h != 0 || v != 0) && !hitting){ 
                                moveAvatar(0);
                            }
                        }
                }catch(System.Exception){
                    throw;
                }
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
    private void OnTriggerEnter(Collider other) {
        Vector3 dirAtual = transform.position;
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
