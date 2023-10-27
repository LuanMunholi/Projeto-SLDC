using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_VerificaBarril : MonoBehaviour
{
    public bool temBarril = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barril"))
        {
            temBarril = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barril"))
        {
            temBarril = false;
        }
    }

    public bool GiveEstado()
    {
        return temBarril;
    }
}

