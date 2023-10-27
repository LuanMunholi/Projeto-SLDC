using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_VerificaPlayer : MonoBehaviour
{
    public bool temPlayer = false;
    public GameObject barril;

    private void OnTriggerEnter(Collider other)
    {
        // Verifique se o objeto que entrou no Collider tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Quando o jogador com a tag "Player" entra no Collider da c�lula, defina a c�lula como ocupada
            temPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifique se o objeto que saiu do Collider tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Quando o jogador com a tag "Player" sai do Collider da c�lula, defina a c�lula como n�o ocupada
            temPlayer = false;
        }
    }

    public bool GiveEstado()
    {
        return temPlayer;
    }
}

