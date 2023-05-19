using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] menu_music;
    public AudioClip[] game_music;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);


    }
    private void OnLevelWasLoaded(int level)
    {

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            
                source.clip = game_music[Random.Range(0, game_music.Length)];
                source.Play();
            

        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Credits")
        {
            if (!source.isPlaying)
            {
                source.clip = menu_music[Random.Range(0, menu_music.Length)];
                source.Play();
            }
        } else if(SceneManager.GetActiveScene().name == "GameScene")
        {
            if (!source.isPlaying)
            {
                source.clip = game_music[Random.Range(0, game_music.Length)];
                source.Play();
            }
            
        }

    }




}
