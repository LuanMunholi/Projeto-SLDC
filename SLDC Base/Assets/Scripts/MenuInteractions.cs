using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractions : MonoBehaviour
{

    public void LoadMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
   
    public void LoadBaseLevel(){
        SceneManager.LoadScene("Cena Base");
    }

    public void QuitGame(){
        Application.Quit();
    }

}
