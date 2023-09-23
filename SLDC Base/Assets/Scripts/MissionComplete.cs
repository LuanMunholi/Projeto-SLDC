using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionComplete : MonoBehaviour
{

    [SerializeField] public GameObject successMenu;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player"))
            LevelComplete();
    }

    private void LevelComplete(){
        successMenu.SetActive(true);
    }

}
