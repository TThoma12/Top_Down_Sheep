using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public bool gameOn = true;
    public GameObject sheep, player;
    public GameObject pauseMenu;
    public GameObject sheep_prefab;
    public float player_health = 10;
    [Header("Audio")]
    public AudioClip menu_clip;
    public AudioSource AudioSource, source2;



    private void Start()
    {

        







        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


            AudioSource = GetComponent<AudioSource>();

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

   
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
        AudioSource.Play();

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioSource.Play();

    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManage.Instance.LoadScene("MainMenu");
        AudioSource.Play();


    }

    public void OpenSettings()
    {
        SceneManage.Instance.LoadScene("SettingsMenu");
        AudioSource.Play();

    }

    public void Back()
    {
        SceneManage.Instance.GoBack();
        AudioSource.Play();

    }


}//void
