using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameOn = true;
    public GameObject pauseMenu;
    public float diff = 1;
    public float player_health = 10;



    public void PlayerGetDamage(float damage)
    {
        player_health -= damage;
    }
    public void GameOn(bool it = true)
    {
        if (it == true) Time.timeScale = 1;
        if (it == false) Time.timeScale = 0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        
    }

    

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

}//void
