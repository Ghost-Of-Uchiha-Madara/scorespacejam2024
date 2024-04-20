using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float patrolOffset = 2f;  
    public SpriteRenderer spriteRenderer;
    bool isMovingLeft = true;
    Vector3 targetPosition;

    public float distanceBeforeAttackingPlayer;
    float distance;
    bool hasFoundPlayer = false;

    Transform playerTransform;
    private void Start()
    {
        
        targetPosition = transform.position - new Vector3(patrolOffset, 0f, 0f);
    }

    private void Update()
    {
        distance = transform.position.x - targetPosition.x;

        if (distance <= 0 && isMovingLeft || distance >=     0 && !isMovingLeft)
        {
            ChangeDirection();
        }

        // Move towards target
        if (!hasFoundPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            AttackPlayer();
        }
    }

    private void ChangeDirection()
    {
        isMovingLeft = !isMovingLeft;
        spriteRenderer.flipX = isMovingLeft;

        if (isMovingLeft)
        {
            targetPosition = transform.position - new Vector3(patrolOffset, 0f, 0f);
        }
        else
        {
            targetPosition = transform.position + new Vector3(patrolOffset, 0f, 0f);
        }
    }

    void AttackPlayer()
    {
        //taking only player's x because the enemy cant jump
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(playerTransform.position.x, transform.position.y), speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, playerTransform.position) < distanceBeforeAttackingPlayer)
        {
            print("CAN ATTACK");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
            hasFoundPlayer= true;
        }
    }

}
