using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldEndAltarController : MonoBehaviour
{
    public float timer_max = 10, timer;
    public int sheep_ct = 0;
    public float game_time = 0;
    private bool game_over = false;
    public GameObject gameEnd_menu;
    public TextMeshProUGUI Score, Record;

    private void Start()
    {
        timer = timer_max;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) timer = timer_max;
        if (collision.CompareTag("Sheep")) sheep_ct -= 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sheep"))
        {
            sheep_ct += 1;
        }
    }
    private void Update()
    {
        if (!game_over)
        {
            game_time += Time.deltaTime;
        }


        if(timer <= 0)
        {
            game_over = true;
            float survival_rate = (float)sheep_ct / PlayerPrefs.GetInt("sheeps");
            float time_bonus = 1 / (game_time - timer_max);
            float difficulty_multiplier = 1 + (SceneManage.Instance.sheep_counter - 1) * 2f;

            int score =(int)(10000 * survival_rate * time_bonus * difficulty_multiplier);


            Debug.Log("You win\nScore: " + score);
            if (PlayerPrefs.HasKey("Record"))
            {
                int record = PlayerPrefs.GetInt("Record");
                if (record < score)
                {
                    record = score;
                    PlayerPrefs.SetInt("Record", record);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Record", score);
            }
            Record.text = "Record: " + PlayerPrefs.GetInt("Record");
            Score.text = "Your Score: " + score;
            gameEnd_menu.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Win");
        }
    }

}
