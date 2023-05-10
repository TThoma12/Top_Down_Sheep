using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    private GameObject sheep;
    private Rigidbody2D rb;
    [Header("Wolf")]
    public float health = 3, maxHealth = 3;
    public float speed = 6;
    public float wolfDamage = 1;
    public float minCoolDown = 1, maxCooldown = 6;
    private float Cooldown;

    private GameController control;
    private Vector2 targetPosition;
    private bool isAnrgy = false;
    private float r_timer = 20f, Timer;

    private void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Timer = r_timer;
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
        double percent_health = ((double)health * 100) / maxHealth;
        Debug.Log(percent_health);
        if (percent_health == 100)
        {
            Timer = r_timer;
            if (!isAnrgy)
            {
                if(Vector2.Distance(this.gameObject.transform.position, sheep.transform.position) < 15f)
                {
                    Attack(sheep.transform.position);
                }
                else
                {
                    MoveAround();
                }
                
            }
            else if(isAnrgy)
            {
                
                if (Vector2.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position) < 15f)
                {
                    Attack(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
                } else if (Vector2.Distance(this.gameObject.transform.position, sheep.transform.position) < 25f)
                {
                    Attack(sheep.transform.position);
                }





            }
            
            
        } else if(percent_health < 100 && percent_health > 30)
        {
            
            
            isAnrgy = true;

            
            
            if (Vector2.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position) < 15f)
            {
                Attack(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
            }
            else if (Vector2.Distance(this.gameObject.transform.position, sheep.transform.position) < 25f)
            {
                Attack(sheep.transform.position);
            }
            else
            {
                Regenerate();
                MoveAround();
            }






        } else if(percent_health <= 30)
        {
            if (Vector2.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position) < 15)
            {
                if (Vector2.Distance(this.gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position) < 15)
                {
                    EscapeFromPlayer();
                }
                else
                {
                    Regenerate();
                    MoveAround();

                }
            }
            else
            {
                if(Vector2.Distance(sheep.transform.position, this.gameObject.transform.position) < 25f)
                {
                    Attack(sheep.transform.position);
                    Regenerate();
                }
            } 

           
        }

        
        if (health <= 0) Object.Destroy(this.gameObject);
    }
    private void Regenerate()
    {
        Timer -= Time.deltaTime;
        Debug.Log(Timer);
        if(Timer <= 0)
        {
            health += 0.5f * GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().diff;
            Timer = r_timer;
        }
        
    }
    public void GetDamage(float damage)
    {
        health -= damage;
    }

    private void Attack(Vector2 target)
    {
        Vector2 target_pos = target;
        Vector2 target_position = target_pos;
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
        } else if (collision.gameObject.CompareTag("Player"))
        {
            control.PlayerGetDamage(wolfDamage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            sheep.GetComponent<SheepController>().GetDamage(wolfDamage / 50);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            control.PlayerGetDamage(wolfDamage / 50);
        }
    }

    void EscapeFromPlayer()
    {



        Vector2 directionFromWolf = ((Vector2)transform.position - (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        Vector2 randomDirection = Random.insideUnitCircle.normalized * 0.3f;
        Vector2 escapeDirection = directionFromWolf + randomDirection;

        targetPosition = (Vector2)transform.position + escapeDirection * 10;


        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}