using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManage.Instance.LoadScene("GameScene");
    }
}
