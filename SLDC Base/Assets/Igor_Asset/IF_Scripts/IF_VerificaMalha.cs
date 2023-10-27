using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_VerificaMalha : MonoBehaviour
{
    public bool ocupada = false; // Indica se a célula está ocupada
    public bool barril = false;

    private void OnTriggerEnter(Collider other)
    {
        // Quando algo entra no Collider da célula, defina a célula como ocupada
        ocupada = true;

        if (other.CompareTag("Barril"))
        {
            barril = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Quando algo sai do Collider da célula, defina a célula como não ocupada
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
