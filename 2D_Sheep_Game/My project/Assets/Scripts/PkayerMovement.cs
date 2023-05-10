using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkayerMovement : MonoBehaviour
{
    public float speed = 20;

    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wolf")) collision.gameObject.GetComponent<WolfController>().GetDamage(0.5f);
    }

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(hor, ver);

        if(velocity.magnitude != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
               
                rb.position += velocity * Time.deltaTime * speed * 3;
            }
            else
            {
                rb.position += velocity * speed * Time.deltaTime;
            }
            ;
        }

        





    }//Update



}//void
