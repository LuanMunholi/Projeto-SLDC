using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barril : MonoBehaviour
{
    public GameObject jogador;

    public GameObject[] posicoesvalidas;

    public VerificaPlayer frente;
    public VerificaPlayer costas;
    public VerificaPlayer direita;
    public VerificaPlayer esquerda;

    private GameObject posicaoAtual;
    private GameObject posicaoFrente;
    private GameObject posicaoTras;
    private GameObject posicaoDireita;
    private GameObject posicaoEsquerda;

    public int i = 2;
    public int j = 2;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (frente.GiveEstado() && PodeMoverPara(i,j-1)) // se esta na frente tem q verificar as costas
        {
            Debug.Log("player esta na frente");
        }
        if (costas.GiveEstado() && PodeMoverPara(i, j + 1))
        {
            Debug.Log("player esta na costas");
        }
        if (direita.GiveEstado() && PodeMoverPara(i - 1, j))
        {
            Debug.Log("player esta na direita");
        }
        if (esquerda.GiveEstado() && PodeMoverPara(i + 1, j))
        {
            Debug.Log("player esta na esquerda");
        }
    }

    void AtualizarPosicoes()
    {
        posicaoAtual = posicoesvalidas[EncontrarIndex(i, j)];
        posicaoFrente = posicoesvalidas[EncontrarIndex(i, j + 1)];
        posicaoTras = posicoesvalidas[EncontrarIndex(i, j - 1)];
        posicaoDireita = posicoesvalidas[EncontrarIndex(i + 1, j)];
        posicaoEsquerda = posicoesvalidas[EncontrarIndex(i - 1, j)];
    }
    int EncontrarIndex(int x, int y)
    {
        for (int index = 0; index < posicoesvalidas.Length; index++)
        {
            if (posicoesvalidas[index].transform.position.x == x && posicoesvalidas[index].transform.position.z == y)
            {
                return index;
            }
        }
        return -1; // Não encontrou a posição
    }
    void movetwo(int x, int y, int z)
    {
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), Mathf.Round(z));
    }
    bool PodeMoverPara(int novoI, int novoJ)
    {
        int index = EncontrarIndex(novoI, novoJ);
        if (index != -1)
        {
            // Obtém o componente Igor_VerificaMalha da célula da grade
            Igor_VerificaMalha malha = posicoesvalidas[index].GetComponent<Igor_VerificaMalha>();
            return !malha.GiveEstadoOcupado(); // Retorna verdadeiro se a célula não estiver ocupada
        }
        return false; // Não encontrou a posição
    }
}
