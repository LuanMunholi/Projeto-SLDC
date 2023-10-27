using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_ControleCameras : MonoBehaviour
{
    public Camera[] cameras;
    private Camera currentCamera;

    private void Start()
    {
        if (cameras.Length > 0)
        {
            // Desative todas as c�meras no in�cio
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }

            // Ative a primeira c�mera da lista
            currentCamera = cameras[0];
            currentCamera.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desative a c�mera atual
            currentCamera.enabled = false;

            // Encontre a c�mera associada ao colisor que o jogador entrou
            foreach (Camera camera in cameras)
            {
                if (camera.GetComponent<Collider>() == other)
                {
                    currentCamera = camera;
                    currentCamera.enabled = true;
                    break;
                }
            }
        }
    }
}
