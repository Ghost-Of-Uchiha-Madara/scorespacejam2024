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

    public Animator enemyAnimator;

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
        LookAtPlayer();
        if (Vector3.Distance(transform.position, playerTransform.position) < distanceBeforeAttackingPlayer)
        {
            print("CAN ATTACK");
            enemyAnimator.SetBool("IsRange", true);
        }
        else
        {
            enemyAnimator.SetBool("IsRange", false);
        }
    }

    void LookAtPlayer()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            // Player is on the right, face right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            // Player is on the left, face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Check player");
            playerTransform = collision.transform;
            hasFoundPlayer= true;
        }
    }

}
