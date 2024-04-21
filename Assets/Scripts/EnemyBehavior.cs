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

    public GameObject debugCircle;

    public HealthSystem healthSystem;

    public GameObject enemyCollider;

    float attackOffsetX;
    private void Start()
    {
        
        targetPosition = transform.position - new Vector3(patrolOffset, 0f, 0f);
    }

    private void Update()
    {
        

        // Move towards target
        if (!hasFoundPlayer)
        {
            distance = transform.position.x - targetPosition.x;

            if (distance <= 0 && isMovingLeft || distance >= 0 && !isMovingLeft)
            {
                ChangeDirection();
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            spriteRenderer.flipX = false;
            AttackPlayer();
        }
    }

    private void ChangeDirection()
    {
        print("change dir");
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

    //void AttackPlayer()
    //{
    //    //taking only player's x because the enemy cant jump
    //    transform.position = Vector3.MoveTowards(transform.position, new Vector2(playerTransform.position.x, transform.position.y), speed * Time.deltaTime);
    //    LookAtPlayer();
    //    if (Vector3.Distance(transform.position, playerTransform.position) < distanceBeforeAttackingPlayer)
    //    {
    //        print("CAN ATTACK");
    //        enemyAnimator.SetBool("IsRange", true);
    //    }
    //    else
    //    {
    //        enemyAnimator.SetBool("IsRange", false);
    //    }
    //}

    void AttackPlayer()
    {
        // Define the attack offset based on enemy's side
        //Vector2 attackOffset = new Vector2(1f, 0f);  // Example offset: 1 unit to the right

        attackOffsetX = 0f;
        if (transform.position.x < playerTransform.position.x)
        {
            attackOffsetX = -1f;  // Offset to the right if enemy is on the left
            //print("left");
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            attackOffsetX = 1f; // Offset to the left if enemy is on the right
            //print("right");
        }
        Vector2 attackOffset = new Vector2(attackOffsetX, 0f);

        // Move towards player's position with offset
        Vector2 updatedTargetPosition = new Vector2(playerTransform.position.x + attackOffset.x, transform.position.y);
        
        transform.position = Vector3.MoveTowards(transform.position, updatedTargetPosition, speed * Time.deltaTime);
        debugCircle.transform.position = updatedTargetPosition;
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
            print("turning right");
        }
        else
        {
            // Player is on the left, face left
            transform.localScale = new Vector3(-1f, 1f, 1f);
            print("turning left");
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //print("Check player");
            playerTransform = collision.transform;
            hasFoundPlayer= true;
        }
    }

    public void EnableCollider()
    {
        enemyCollider.SetActive(true);
    }

    public void DisableCollider()
    {
        enemyCollider.SetActive(false);
    }

}
