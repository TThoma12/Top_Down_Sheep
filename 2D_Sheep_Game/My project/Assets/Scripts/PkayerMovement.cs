using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkayerMovement : MonoBehaviour
{
    public float speed = 20;

    private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wolf")) collision.gameObject.GetComponent<WolfController>().GetDamage(1.0f);
    }

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector2 velocity = new Vector2(hor, ver);

        if(velocity.magnitude != 0)
        {
            rb.position += velocity * speed * Time.deltaTime;
        }

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.x *= 20;
            velocity.y *= 20;
            rb.position += velocity * Time.deltaTime;
        }*/





    }//Update



}//void
