using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera initialCamera;
    public CinemachineVirtualCamera cutScene; // Reference to the initial virtual camera
    public CinemachineVirtualCamera newCamera; // Reference to the virtual camera to be enabled for 30 seconds

    private bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

            if(!isActive){
                initialCamera.Priority = 10;
                cutScene.Priority = 11;
                isActive = true;
                Invoke("SwitchBackToInitialCamera", 3f);
            }

        }
    }

    void SwitchBackToInitialCamera()
    {

        newCamera.Priority = 11;
        cutScene.Priority = 10;

    }
}
