using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartGameButton : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI counter;

    private void Start()
    {

        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        counter = GameObject.FindGameObjectWithTag("SheepCounter").GetComponent<TextMeshProUGUI>();


    }



    private void Update()
    {

        PlayerPrefs.SetInt("sheeps", (int)slider.value);
        counter.text = "Number of sheeps: " + PlayerPrefs.GetInt("sheeps");
    }

  

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManage.Instance.LoadScene("GameScene");
    }
}
