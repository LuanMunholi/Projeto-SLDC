using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject pauseMenu;
    public static bool isPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame(){
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

}
