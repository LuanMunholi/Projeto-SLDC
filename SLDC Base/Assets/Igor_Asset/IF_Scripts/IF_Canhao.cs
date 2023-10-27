using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_Canhao : MonoBehaviour
{
    public GameObject projetilPrefab; // O prefab do projétil que será disparado.
    public Transform pontoDeDisparo;   // O ponto de onde o projétil será disparado.
    private Collider jogadorColisor;   // Colisor do jogador.
    public int forcaDisparo = 10;
    public float tempoDeVida = 3.0f; // Tempo de vida do projetil em segundos.

    void Start()
    {
        jogadorColisor = null;
    }

    void Update()
    {
        if (jogadorColisor != null && Input.GetKeyDown(KeyCode.E))
        {
            DispararProjetil();
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

    void DispararProjetil()
    {
        if (projetilPrefab != null && pontoDeDisparo != null)
        {
            GameObject projetil = Instantiate(projetilPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);
            Rigidbody rb = projetil.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Adicione a força ao projetil aqui.
                rb.AddForce(pontoDeDisparo.forward * forcaDisparo, ForceMode.Impulse);
            }

            // Destrua o projetil após o tempo de vida especificado.
            Destroy(projetil, tempoDeVida);
        }
    }
}
