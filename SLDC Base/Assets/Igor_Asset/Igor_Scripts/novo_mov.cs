using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novo_mov : MonoBehaviour
{
    public int i = 0; // Coordenada I inicial
    public int j = 0; // Coordenada J inicial


    //public Transform[,] pontosDeReferencia; // Matriz para rastrear os pontos de refer�ncia
    //public float velocidadeMovimento = 5f;


    public GameObject cell;
    public List<GameObject> posicoesValidas = new List<GameObject>();



    //private Igor_VerificaMalha malha;

    void Start()
    {
        // Inicializa a matriz de c�lulas ocupadas (defina as dimens�es conforme necess�rio)

        // Inicializa a matriz de pontos de refer�ncia (defina as posi��es conforme necess�rio)
        //       pontosDeReferencia = new Transform[i, j];

        // Popule a matriz de pontos de refer�ncia e defina os valores de ocupado conforme necess�rio
        // Exemplo:
        // pontosDeReferencia[0, 0] = pontoDeReferenciaInicial;
        // celulasOcupadas[0, 0] = false;

        // Defina a posi��o inicial do jogador
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

