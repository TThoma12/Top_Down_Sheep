using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksController : MonoBehaviour
{
    public Dictionary<string, bool> tasks = new Dictionary<string, bool> 
    {
        {"FindSheep", false },
        {"GuideSheep", false }
    
    };


    public void TaskComplete(string task_name)
    {
        tasks[task_name] = true;
    }


}
