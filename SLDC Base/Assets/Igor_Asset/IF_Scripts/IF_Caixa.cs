using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using static UnityEngine.EventSystems.EventTrigger;

public class IF_Caixa : MonoBehaviour
{
    public GameObject[] bolaCanhao;

    private Collider jogadorColisor;


    // Start is called before the first frame update
    void Start()
    {
        jogadorColisor = null;
    }

    void Update()
    {
        if (jogadorColisor != null && Input.GetKeyDown(KeyCode.E))
        {
            removerBola();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorColisor = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == jogadorColisor)
        {
            jogadorColisor = null;
        }
    }

    private void removerBola()
    {
        if (bolaCanhao.Length > 0)
        {
            GameObject bolaParaRemover = bolaCanhao[0]; // Pega o primeiro objeto do vetor.
            Destroy(bolaParaRemover); // Destroi o objeto.

            // Remove o objeto do vetor.
            List<GameObject> novaLista = new List<GameObject>(bolaCanhao);
            novaLista.RemoveAt(0);
            bolaCanhao = novaLista.ToArray();
        }
    }

}
