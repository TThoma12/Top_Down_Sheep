using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public bool gameOn = true;
    public GameObject player;
    public GameObject sheep;
    public GameObject pauseMenu;
    public float diff = 1;
    public float player_health = 10;
    [Header("Audio")]
    public AudioClip menu_clip;
    private AudioSource audio;



    private void Start()
    {
        audio = GetComponent<AudioSource>();
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
        Time.timeScale = 1;
        SceneManage.Instance.LoadScene("GameScene");
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        audio.Play();
    }

    public void Quit()
    {
        Application.Quit();
        audio.Play();

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        audio.Play();

    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManage.Instance.LoadScene("MainMenu");
        audio.Play();


    }

    public void OpenSettings()
    {
        SceneManage.Instance.LoadScene("SettingsMenu");
        audio.Play();

    }

    public void Back()
    {
        SceneManage.Instance.GoBack();
        audio.Play();

    }


}//void
