using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    private GameObject sheep;
    private Rigidbody2D rb;
    [Header("Wolf")]
    public float health = 3;
    public float speed = 6;
    public float wolfDamage = 1;
    public float minCoolDown = 1, maxCooldown = 6;
    private float Cooldown;

    private Vector2 targetPosition;


    private void Start()
    {
        sheep = GameObject.FindGameObjectWithTag("Sheep");
        rb = GetComponent<Rigidbody2D>();
        Cooldown = Random.Range(minCoolDown, maxCooldown);
        targetPosition = transform.position;
        StartCoroutine(ChangeTargetPosition());

    }

    IEnumerator ChangeTargetPosition()
    {
        while (true)
        {
            float x = Random.Range(-6, 6);
            float y = Random.Range(-6, 6);
            targetPosition = new Vector2(x, y);

            float waitTime = Random.Range(minCoolDown, maxCooldown);
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void Update()
    {
        AttackSheep();
        if (health <= 0) Object.Destroy(this.gameObject);
    }

    public void GetDamage(float damage)
    {
        health -= damage;
    }

    private void AttackSheep()
    {
        Vector2 sheep_pos = sheep.transform.position;
        Vector2 target_position = sheep_pos;
        float distance = Vector2.Distance(target_position, transform.position);
        if (distance <= 20)
        {
            transform.position = Vector2.MoveTowards(transform.position, target_position, speed * Time.deltaTime);
        }
        else
        {
            MoveAround();
        }

    }

    private void MoveAround()
    {
          Cooldown -= Time.deltaTime;

          if(Cooldown <= 0)
          {
              float x = Random.Range(-6.0f, 6.0f);
              float y = Random.Range(-6.0f, 6.0f);
              Vector2 randomposition = new Vector2(x, y);
            




            
           
            Vector2 target_position = (Vector2)transform.position + randomposition;

             Debug.Log(randomposition);
              rb.MovePosition(target_position * Time.deltaTime * speed);
              Cooldown = Random.Range(minCoolDown, maxCooldown);
              Debug.Log(Cooldown);

          }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            sheep.GetComponent<SheepController>().GetDamage(wolfDamage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            sheep.GetComponent<SheepController>().GetDamage(wolfDamage / 50);
        }
    }

}