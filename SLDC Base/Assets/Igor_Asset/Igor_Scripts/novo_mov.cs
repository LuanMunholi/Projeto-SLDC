using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novo_mov : MonoBehaviour
{
    public int i = 0; // Coordenada I inicial
    public int j = 0; // Coordenada J inicial


    //public Transform[,] pontosDeReferencia; // Matriz para rastrear os pontos de referência
    //public float velocidadeMovimento = 5f;


    public GameObject cell;
    public List<GameObject> posicoesValidas = new List<GameObject>();



    //private Igor_VerificaMalha malha;

    void Start()
    {
        // Inicializa a matriz de células ocupadas (defina as dimensões conforme necessário)

        // Inicializa a matriz de pontos de referência (defina as posições conforme necessário)
        //       pontosDeReferencia = new Transform[i, j];

        // Popule a matriz de pontos de referência e defina os valores de ocupado conforme necessário
        // Exemplo:
        // pontosDeReferencia[0, 0] = pontoDeReferenciaInicial;
        // celulasOcupadas[0, 0] = false;

        // Defina a posição inicial do jogador
        //      transform.position = pontosDeReferencia[i, j].position;


        //malha = GetComponent<Igor_VerificaMalha>();
    }

    void Update()
    {
        //if (malha.GiveEstado() == false)
        
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                j++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                j--;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                i--;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                i++;
            }

        movetwo(i, 2, j);
    }



    void movetwo(int x, int y,int z)
    {
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), Mathf.Round(z));
        //Vector3 currentPosition = new Vector3(Mathf.Round(x), Mathf.Round(y), Mathf.Round(z));
    }

}

