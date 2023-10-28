using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_Portinhola : MonoBehaviour
{
    private Collider jogadorColisor;

    public GameObject portinhola;

    public Vector3 fechado = new Vector3(90, 90, 90);
    public Vector3 aberto = new Vector3(90, 90, 90);

    private bool portinholaAberta = false;

    void Start()
    {
        jogadorColisor = null;
    }

    void Update()
{
    if (jogadorColisor != null && Input.GetKeyDown(KeyCode.E))
    {
        // Chame a função movePortinhola e passe a referência da portinhola que você deseja controlar
        movePortinhola();
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

    void movePortinhola()
    {
        // Obtém a referência do transform da portinhola
        Transform portinholaTransform = portinhola.transform;

        if (portinholaAberta)
        {
            // Se a portinhola estiver aberta, fecha-a
            portinholaTransform.eulerAngles = fechado;
            portinholaAberta = false;
        }
        else
        {
            // Se a portinhola estiver fechada, abre-a
            portinholaTransform.eulerAngles = aberto;
            portinholaAberta = true;
        }
    }
}
