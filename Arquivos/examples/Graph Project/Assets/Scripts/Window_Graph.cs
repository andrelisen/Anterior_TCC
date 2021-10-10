using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_Graph : MonoBehaviour
{
    //Sprite em formato de circulo referente aos pontos do gráfico
    [SerializeField] private Sprite circleSprite;

    //Referencia para o material do circulo
    // [SerializeField] private Material colorCircle;

    //Referência para o container onde o gráfico será renderizado
    private RectTransform graphContainer;

    //Referência aos labelTemplate x e y
    private RectTransform labelTemplateX; 
    private RectTransform labelTemplateY;

    //Referência as linhas do gráfico
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;

    private void Awake(){
        //procura e pga referencia do container onde os pontos serão inseridos
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();

        //procura e pega referncia do label x e y
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        
        //procura e pega referncia das linhas x e y
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        //Cria circulo mandando sua posição 
        // CreateCircle(new Vector2(200, 200));

        //Cria uma lista de valores que serão renderizados no gráfico
        List<int> valueList = new List<int>(){5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33};
        ShowGraph(valueList);

    }

    //Função que ira criar o ponto no container graphcontainer - retorno do objeto criado
    private GameObject CreateCircle(Vector2 anchoredPosition){
        //Cria um elemento do gráfic
        GameObject gameObject = new GameObject("circle", typeof(Image));
        //Adiciona circulo como sendo um filho do graphcontainer
        gameObject.transform.SetParent(graphContainer, false);
        //Seta sprite circulo para o formato do gameobject e o material para red
        gameObject.GetComponent<Image>().sprite = circleSprite;
        // gameObject.GetComponent<Image>().material = colorCircle;

        //Pega referencia para rect transform
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //define a posição onde ficara o circulo
        rectTransform.anchoredPosition = anchoredPosition;
        //define o tamanho do circulo em rectTransform
        rectTransform.sizeDelta = new Vector2(11, 11); //TAMANHO
        //Seta ele para inicializar no lado esquerdo minimo
        rectTransform.anchorMin = new Vector2(0, 0); //principal em 0,0
        rectTransform.anchorMax = new Vector2(0, 0); //principal em 0,0

        return gameObject;
    }


    //Função que irá ler uma lista de valores que deverá ser representado no gráfico
    private void ShowGraph(List<int> valueList){
        float graphHeight = graphContainer.sizeDelta.y; //Altura do container aonde vai os pontos no eixo y 
        float yMaximum = 100f; //valor mais alto - topo do gráfico 
        float xSize = 50f; //distancia entre cada um dos pontos no eixo x 

        //Referencia para o próximo gameobject - no caso o próximo ponto onde preciso criar uma linha 
        GameObject lastCircleGameObject = null;

        //x = posição em i; y = calcular      
        for(int i = 0; i< valueList.Count; i++){
            float xPosition = xSize + i * xSize; //soma +xSize para que o gráfico não comece bem na esquerda tenha um espaço
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            //Manda criar o ponto calculado no gráfico - retorna objeto criado
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            //Verifica se este não é o primeiro ponto
            if(lastCircleGameObject != null){//Não é o primeiro ponto
                //Conecta um ponto a outro - enviando sua posição
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            //Renderiza labels com o valor de x
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            //Seta posição do label - mesma em x para o ponto e Configura o y para -20f
            labelX.anchoredPosition = new Vector2(xPosition, -7f);
            labelX.GetComponent<Text>().text = i.ToString();

            //Renderiza linha do gráfico em x
            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            //Seta posição do label - mesma em x para o ponto e Configura o y para -20f
            dashY.anchoredPosition = new Vector2(xPosition, -3f);

        }

        //Para renderizar os labels com o valor de y
        int separatorCount = 10; //Supondo 10 
        for(int i = 0; i <= separatorCount; i++){
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            //Retorna um valor entre 0 e separatorCount
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();

            //Renderiza linha do gráfico em y
            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            //Seta posição do label - mesma em x para o ponto e Configura o y para -20f
            dashX.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);

        }


    } 

    //Função para criar uma linha entre os pontos
    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB){
        //Objeto que irá criar a linha 
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        //Seta a linha para dentro do container
        gameObject.transform.SetParent(graphContainer, false);
        //Troca a cor da linha 
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        // gameObject.GetComponent<Image>().color = Color.red;
        //Coleta direção para onde deve apontar a linha
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        //Calcula a distancia entre os pontos 
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        //Pega referência para o Rect Transform da linha
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        //Seta inicio para inferior esquerda 
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        //Configura tamanho da linha
        rectTransform.sizeDelta = new Vector2(distance, 3f); //usa o valor da distancia para o tamanho
        //Seta posição da linha
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        //Angulo de giro da linha calculo apartir de Euler
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

}
