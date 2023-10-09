using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luan_FallTrap : MonoBehaviour
{
    
    private Rigidbody rb;
    private bool steppedOn = false;
    private float timeSinceSteppedOn = 0f;
    public float fallDelay = 0.1f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (steppedOn)
        {
            timeSinceSteppedOn += Time.deltaTime;

            if (timeSinceSteppedOn >= fallDelay)
            {
                rb.isKinematic = false; // Allow the platform to fall
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !steppedOn)
        {
            steppedOn = true;
        }
    }

}