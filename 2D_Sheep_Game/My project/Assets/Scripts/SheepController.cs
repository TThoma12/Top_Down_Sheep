using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{


    public bool isFolow = true;
    public Transform player;
    [Header("Movement")]
    public float followDistance = 3.0f;
    public float moveSpeed = 2.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float minCoolDown = 1.0f, maxCoolDown = 2.0f;
    public float rushSpeedMultiplier = 2.0f;
    [Header("Sheep")]
    public float health = 3;
    public float escapeDistance = 20.0f;
    private GameController control;

    [Header("Panic")]
    public float panicChangeDirectionInterval = 0.5f;
    private float panicChangeDirectionTimer;

    private Vector2 targetPosition;
    private float changeDirectionTimer;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        changeDirectionTimer = Random.Range(minCoolDown, maxCoolDown);
        panicChangeDirectionTimer = panicChangeDirectionInterval;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
    }


    void Update()
    {

        GameObject closestWolf = FindClosestWolf();
        if (closestWolf != null && Vector2.Distance(transform.position, closestWolf.transform.position) <= escapeDistance)
        {
            EscapeFromWolf(closestWolf);
        }
        else
        {
            if (isFolow) Follow();
            Sheep();
        }


    }

    private void Sheep()
    {
        //if (health <= 0) control.GameOn(false);


    }


    private void Follow()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < maxDistance + 3)
        {
            changeDirectionTimer -= Time.deltaTime;

            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < minDistance)
            {
                SetNewTargetPosition();
                changeDirectionTimer = Random.Range(minCoolDown, maxCoolDown);

            }
            else if (distance > maxDistance)
            {
                targetPosition = (Vector2)player.position;
            }


            if (changeDirectionTimer <= 0)
            {
                SetNewTargetPosition();
                changeDirectionTimer = Random.Range(minCoolDown, maxCoolDown);
                Debug.Log(changeDirectionTimer);
            }

            float currentMoveSpeed = distance > maxDistance ? moveSpeed * rushSpeedMultiplier : moveSpeed;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);
        }

    }


    void SetNewTargetPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 directionToPlayer = ((Vector2)player.position - (Vector2)transform.position).normalized;
        float angle = Vector2.Angle(randomDirection, directionToPlayer);

        while (angle < 45.0f)
        {
            randomDirection = Random.insideUnitCircle.normalized;
            angle = Vector2.Angle(randomDirection, directionToPlayer);
        }

        targetPosition = (Vector2)player.position + randomDirection * followDistance;
    }

    GameObject FindClosestWolf()
    {
        GameObject[] wolves = GameObject.FindGameObjectsWithTag("Wolf");
        GameObject closestWolf = null;
        float closestDistance = escapeDistance;

        foreach (GameObject wolf in wolves)
        {
            float distance = Vector2.Distance(transform.position, wolf.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestWolf = wolf;
            }
        }

        return closestWolf;
    }

    void EscapeFromWolf(GameObject closestWolf)
    {
        panicChangeDirectionTimer -= Time.deltaTime;


            Vector2 directionFromWolf = ((Vector2)transform.position - (Vector2)closestWolf.transform.position).normalized;
            Vector2 randomDirection = Random.insideUnitCircle.normalized * 0.3f;
            Vector2 escapeDirection = directionFromWolf + randomDirection;

            targetPosition = (Vector2)transform.position + escapeDirection * escapeDistance;

            panicChangeDirectionTimer = Random.Range(minCoolDown, maxCoolDown);
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }





}//void