using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luan_Death : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
          other.transform.position = respawnPoint.position;
            
        }
    }
}
