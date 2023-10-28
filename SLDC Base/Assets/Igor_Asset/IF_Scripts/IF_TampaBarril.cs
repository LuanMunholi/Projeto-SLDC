using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_TampaBarril : MonoBehaviour
{
    private Collider jogadorColisor;

    public GameObject tampa;

    void Start()
    {
        jogadorColisor = null;
    }

    void Update()
    {
        if (jogadorColisor != null && Input.GetKeyDown(KeyCode.E))
        {
            destroyTampa();
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

    void destroyTampa()
    {
        if (tampa != null)
        {
            Destroy(tampa);
        }
    }

}
