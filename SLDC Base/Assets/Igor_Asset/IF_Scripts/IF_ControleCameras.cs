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
            // Desative todas as câmeras no início
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }

            // Ative a primeira câmera da lista
            currentCamera = cameras[0];
            currentCamera.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desative a câmera atual
            currentCamera.enabled = false;

            // Encontre a câmera associada ao colisor que o jogador entrou
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
