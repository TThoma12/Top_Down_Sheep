using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public bool isDelayed = true;
    public float DelayPower = 1;

    private void Update()
    {
        if (isDelayed)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 tr = player.transform.position;
            transform.position = new Vector3(tr.x - hor * DelayPower, tr.y - ver * DelayPower, -10);
        }
        else
        {
 
            Vector3 tr = player.transform.position;
            transform.position = new Vector3(tr.x, tr.y, -10);
        }

       
        
    }



}//void
