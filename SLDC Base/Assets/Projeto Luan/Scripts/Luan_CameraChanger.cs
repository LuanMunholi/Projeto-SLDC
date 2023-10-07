using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Luan_CameraChanger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraToActivate;
    [SerializeField] CinemachineVirtualCamera cameraToDeactivate;

    public bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if(isActive){

                cameraToDeactivate.gameObject.SetActive(true);
                cameraToActivate.gameObject.SetActive(false);
                isActive = false;

            } else if(cameraToDeactivate.gameObject != cameraToActivate.gameObject) {

                cameraToDeactivate.gameObject.SetActive(false);
                cameraToActivate.gameObject.SetActive(true);
                isActive = true;

            }
        }
    }
}
