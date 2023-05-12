using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameOn = true;
    public GameObject player;
    public GameObject pauseMenu;
    public float diff = 1;
    public float player_health = 10;


    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PkayerMovement>();
    }




    public void PlayerGetDamage(float damage)
    {
        player.GetComponent<PkayerMovement>().PlayDamage();

        player_health -= damage;
    }
    public void GameOn(bool it = true)
    {
        if (it == true) Time.timeScale = 1;
        if (it == false) Time.timeScale = 0;
    }

    public void StartGame()
    {

        SceneManage.Instance.LoadScene("SampleScene");
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
        SceneManage.Instance.LoadScene("MainMenu");

    }

    public void OpenSettings()
    {
        SceneManage.Instance.LoadScene("SettingsMenu");
    }

    public void Back()
    {
        SceneManage.Instance.GoBack();
    }


}//void
