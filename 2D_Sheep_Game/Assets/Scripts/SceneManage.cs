using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private static SceneManage instance;

    public float sheep_counter;

    private Stack<string> sceneHistory;

 

    private void Awake()
    {
        


        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            sceneHistory = new Stack<string>();
        }
    }

    public void LoadScene(string sceneName)
    {
        sceneHistory.Push(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void GoBack()
    {
        if (sceneHistory.Count > 0)
        {
            string lastScene = sceneHistory.Pop();
            UnityEngine.SceneManagement.SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.Log("No scenes in history!");
        }
    }



    public static SceneManage Instance { get { return instance; } }
}
