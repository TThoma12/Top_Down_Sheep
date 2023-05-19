using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject start_point, sheep_prefab;




    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
          
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("player");
            start_point = GameObject.FindGameObjectWithTag("StartPoint");
            Debug.Log("start");
            player.transform.position = start_point.transform.position;
            Debug.Log("counted");



            for (int i = 1; i <= PlayerPrefs.GetInt("sheeps"); i++)
            {
                Debug.Log("Summoned " + i);
                Instantiate(sheep_prefab, start_point.transform.position, Quaternion.identity);

            }



        }
    }

    public void Back()
    {
        SceneManage.Instance.GoBack();
    }
}
