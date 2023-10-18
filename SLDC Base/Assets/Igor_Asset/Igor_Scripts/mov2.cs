using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mov2 : MonoBehaviour
{
    //public GameObject jogador;

    public int i = 2;
    public int j = 2;

    public GameObject[] posicoesvalidas;  // Array de posições válidas

    private GameObject posicaoAtual;
    private GameObject posicaoFrente;
    private GameObject posicaoTras;
    private GameObject posicaoDireita;
    private GameObject posicaoEsquerda;

    public VerificaBarril frente;
    public VerificaBarril costas;
    public VerificaBarril direita;
    public VerificaBarril esquerda;

    public bool podeMoverParaFrente = false;
    public bool podeMoverParaCostas = false;
    public bool podeMoverParaDireita = false;
    public bool podeMoverParaEsquerda = false;

    public bool podeMoverBarril = false;

    void Start()
    {
        // Inicialize as posições com base em i e j
        AtualizarPosicoes();
    }

    void Update()
    {
        //moverBarril();
        int novoI = i;
        int novoJ = j;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            novoJ = j + 1;
            podeMoverBarril = false;
            if (frente.GiveEstado() && PodeMoverPara(i, j + 2))
            {
                if (frente.GiveEstado())
                {
                    podeMoverParaFrente = true;
                    podeMoverBarril = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            novoJ = j - 1;
            podeMoverBarril = false;
            if (costas.GiveEstado() && PodeMoverPara(i, j - 2))
            {
                if (costas.GiveEstado())
                {
                    podeMoverParaCostas = true;
                    podeMoverBarril = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            novoI = i - 1;
            podeMoverBarril = false;
            if (esquerda.GiveEstado() && PodeMoverPara(i - 2, j))
            {
                if (esquerda.GiveEstado())
                {
                    podeMoverParaEsquerda = true;
                    podeMoverBarril = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            novoI = i + 1;
            podeMoverBarril = false;
            if (direita.GiveEstado() && PodeMoverPara(i + 2, j))
            {
                if (direita.GiveEstado())
                {
                    podeMoverParaDireita = true;
                    podeMoverBarril = true;
                }
            }
        }

        // Verifica se o jogador pode se mover para a nova posição
        if (PodeMoverPara(novoI, novoJ))
        {
            i = novoI;
            j = novoJ;
            AtualizarPosicoes();
            moverPara(i, 2, j);
        }
    }

    // Verifica se o jogador pode se mover para uma posição
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

    // Atualize as variáveis de posição com base em i e j
    void AtualizarPosicoes()
    {
        posicaoAtual = posicoesvalidas[EncontrarIndex(i, j)];
        posicaoFrente = posicoesvalidas[EncontrarIndex(i, j + 1)];
        posicaoTras = posicoesvalidas[EncontrarIndex(i, j - 1)];
        posicaoDireita = posicoesvalidas[EncontrarIndex(i + 1, j)];
        posicaoEsquerda = posicoesvalidas[EncontrarIndex(i - 1, j)];
    }

    // Encontre o índice no array de posições válidas
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

    void moverPara(int x, int y, int z)
    {
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), Mathf.Round(z));
    }
    
    public bool giveFrente()
    {
        return podeMoverParaFrente;
    }
    public bool giveCostas()
    {
        return podeMoverParaCostas;
    }
    public bool giveDireita()
    {
        return podeMoverParaDireita;
    }
    public bool giveEsquerda()
    {
        return podeMoverParaEsquerda;
    }

}
