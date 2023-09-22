using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadBaseLevel(){
        SceneManager.LoadScene("Cena Base");
    }

    public void QuitGame(){
        Application.Quit();
    }
 
}
