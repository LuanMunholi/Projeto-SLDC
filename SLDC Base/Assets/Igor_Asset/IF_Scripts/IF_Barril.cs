using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_Barril : MonoBehaviour
{
    public IF_Movimentacao jogador;

    public IF_PopulaLista listapopulada;

    public GameObject[] posicoesvalidas;

    public IF_VerificaPlayer frente;
    public IF_VerificaPlayer costas;
    public IF_VerificaPlayer direita;
    public IF_VerificaPlayer esquerda;

    public GameObject posicaoAtual;
    public GameObject posicaoFrente;
    public GameObject posicaoTras;
    public GameObject posicaoDireita;
    public GameObject posicaoEsquerda;

    public int i = 2;
    public int j = 2;


    // Start is called before the first frame update
    void Start()
    {
        posicoesvalidas = listapopulada.populaposicao.ToArray();
        AtualizarPosicoes();

    }

    // Update is called once per frame
    void Update()
    {
        AtualizarPosicoes();
        // verifico se tem um Player na frente, verifico se posso mover para tras
        if (frente.GiveEstado() && PodeMoverPara(i,j-1)) // se esta na frente tem q verificar as costas
        {
            //verifico se o player pode mover para as costas e se o jogador pode mover o barril 
            if (jogador.giveCostas() && jogador.podeMoverBarril)
            {
                j--;
                AtualizarPosicoes();
                movetwo(i, 2, j);
                jogador.podeMoverParaCostas = false;
            }


        }
        if (costas.GiveEstado() && PodeMoverPara(i, j + 1))
        {
            if (jogador.giveFrente())
            {
                j++;
                AtualizarPosicoes();
                movetwo(i, 2, j);
                jogador.podeMoverParaFrente = false;
            }
        }
        if (direita.GiveEstado() && PodeMoverPara(i - 1, j))
        {
            if (jogador.giveEsquerda())
            {
                i--;
                AtualizarPosicoes();
                movetwo(i, 2, j);
                jogador.podeMoverParaEsquerda = false;
            }
        }
        if (esquerda.GiveEstado() && PodeMoverPara(i + 1, j))
        {
            if (jogador.giveDireita())
            {
                i++;
                AtualizarPosicoes();
                movetwo(i, 2, j);
                jogador.podeMoverParaDireita = false;
            }
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
            IF_VerificaMalha malha = posicoesvalidas[index].GetComponent<IF_VerificaMalha>();
            return !malha.GiveEstadoOcupado(); // Retorna verdadeiro se a célula não estiver ocupada
        }
        return false; // Não encontrou a posição
    }
}
