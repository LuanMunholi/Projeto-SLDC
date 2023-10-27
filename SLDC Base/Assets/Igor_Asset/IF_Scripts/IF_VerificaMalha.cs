using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_VerificaMalha : MonoBehaviour
{
    public bool ocupada = false; // Indica se a c�lula est� ocupada
    public bool barril = false;

    private void OnTriggerEnter(Collider other)
    {
        // Quando algo entra no Collider da c�lula, defina a c�lula como ocupada
        ocupada = true;

        if (other.CompareTag("Barril"))
        {
            barril = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando algo sai do Collider da c�lula, defina a c�lula como n�o ocupada
        ocupada = false;

        if (other.CompareTag("Barril"))
        {
            barril = false;
        }
    }
    //GiveEstadoOcupado
    public bool GiveEstadoOcupado()
    {
        return ocupada;
    }

    public bool GiveEstadoBarril()
    {
        return barril;
    }
}
