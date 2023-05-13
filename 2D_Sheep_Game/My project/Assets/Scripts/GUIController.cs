using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
    private GameObject player;
    private SheepController sheep;
    private GameController controller;
    public GameObject GameOverMenu;
    public TextMeshProUGUI reason;

    [Header("PlayerHealth")]
    public GameObject[] player_health;
    [Header("SheepHealth")]
    public GameObject[] sheep_health;





    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sheep = GameObject.FindGameObjectWithTag("Sheep").GetComponent<SheepController>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth();
        SheepHealth();

        if(sheep.health <= 0)
        {
            reason.text = "The sheep have died";
            Time.timeScale = 0;
            GameOverMenu.active = true;
        }

        if(controller.player_health <= 0)
        {
            reason.text = "You have died";
            Time.timeScale = 0;
            GameOverMenu.active = true;
        }

    }

    private void PlayerHealth()
    {
        if(controller.player_health <= 6 && controller.player_health >5)
        {
            player_health[0].active = true;
            player_health[1].active = true;
            player_health[2].active = true;
            player_health[3].active = true;
            player_health[4].active = true;
            player_health[5].active = true;
        }
        else if (controller.player_health <= 5 && controller.player_health > 4)
        {
            player_health[0].active = true;
            player_health[1].active = true;
            player_health[2].active = true;
            player_health[3].active = true;
            player_health[4].active = true;
            player_health[5].active = false;
        }
        else if (controller.player_health <= 4 && controller.player_health > 3)
        {
            player_health[0].active = true;
            player_health[1].active = true;
            player_health[2].active = true;
            player_health[3].active = true;
            player_health[4].active = false;
            player_health[5].active = false;
        }
        else if (controller.player_health <= 3 && controller.player_health > 2)
        {
            player_health[0].active = true;
            player_health[1].active = true;
            player_health[2].active = true;
            player_health[3].active = false;
            player_health[4].active = false;
            player_health[5].active = false;
        } else if (controller.player_health <= 2 && controller.player_health > 1)
        {
            player_health[0].active = true;
            player_health[1].active = true;
            player_health[2].active = false;
            player_health[3].active = false;
            player_health[4].active = false;
            player_health[5].active = false;
        } else if (controller.player_health <= 1)
        {
            player_health[0].active = true;
            player_health[1].active = false;
            player_health[2].active = false;
            player_health[3].active = false;
            player_health[4].active = false;
            player_health[5].active = false;
        }
    }//void

    private void SheepHealth()
    {
        if(sheep.health <= 4 && sheep.health >3)
        {
            sheep_health[0].active = true;
            sheep_health[1].active = true;
            sheep_health[2].active = true;
            sheep_health[3].active = true;
        }
        else if (sheep.health <= 3 && sheep.health > 2)
        {
            sheep_health[0].active = true;
            sheep_health[1].active = true;
            sheep_health[2].active = true;
            sheep_health[3].active = false;
        }
        else if (sheep.health <= 2 && sheep.health > 1)
        {
            sheep_health[0].active = true;
            sheep_health[1].active = true;
            sheep_health[2].active = false;
            sheep_health[3].active = false;
        }
        else if (sheep.health <= 1)
        {
            sheep_health[0].active = true;
            sheep_health[1].active = false;
            sheep_health[2].active = false;
            sheep_health[3].active = false;
        }
    } 

}
