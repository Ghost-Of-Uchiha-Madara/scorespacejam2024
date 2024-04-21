using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float distanceBeforeLightAttack;
    public float distanceBeforeHeavyAttack;
    public float teleportChance; // Chance (0-1) to teleport
    public float teleportCooldown; // Time between teleports
    float nextTeleportTime = 0f;
    float distance;
    //public Animator enemyAnimator;

    public Transform playerTransform;

    public GameObject debugCircle;

    public HealthSystem healthSystem;

    float attackOffsetX;

    public float teleportOffset;

    public Vector2 updatedTargetPosition;

    public float nextAttackTime;

    public float attackCooldownTime;

    public bool isTeleporting = false;

    private void Start()
    {
        StartCoroutine(DelayTeleport());
    }
    private void Update()
    {
        MoveTowardsPlayer();
        LookAtPlayer();
        ChooseAttack();
        TeleportLogic();

        //TeleportDebug();

        //transform.position = Vector3.MoveTowards(transform.position, updatedTargetPosition, speed * Time.deltaTime);
    }

    void TeleportLogic()
    {
        if (Time.time >= nextTeleportTime && Random.value <= teleportChance)
        {
            nextTeleportTime = Time.time + teleportCooldown;

            isTeleporting = true;
            float targetXPosition;

            //check if enemy is left or right
            if (transform.position.x < playerTransform.position.x)
            {
                targetXPosition = playerTransform.position.x + teleportOffset;
            }
            else
            {
                targetXPosition = playerTransform.position.x - teleportOffset;
            }

            Vector2 potentialTeleportPosition = new Vector2(targetXPosition, transform.position.y);

            // Check for colliders at the potential teleport position
            RaycastHit2D hit = Physics2D.Raycast(potentialTeleportPosition, Vector2.up, 0.1f);

            if (!hit.collider) // No collider present, teleport is safe
            {
                transform.position = potentialTeleportPosition;
                //TeleportDebug(transform.position.x < playerTransform.position.x); // Update debug based on teleport direction
                isTeleporting = false;
            }
            else
            {
                Debug.Log("Teleport Blocked by Collider!");
            }
        }
    }

    IEnumerator DelayTeleport()
    {
        teleportChance = 0f;
        yield return new WaitForSeconds(10f);
        teleportChance = Random.Range(0.3f, 0.5f);

    }


    void TeleportDebug(bool isRight)
    {
        //RaycastHit2D hit = Physics2D.Raycast(playerTransform.position, -Vector2.right, teleportOffset);
        if (isRight)
        {
            Debug.DrawRay(playerTransform.position, -Vector2.right * teleportOffset, Color.red);
        }
        else
        {
            Debug.DrawRay(playerTransform.position, Vector2.right * teleportOffset, Color.red);

        }
    }
    void MoveTowardsPlayer()
    {
        attackOffsetX = 0f;
        if (transform.position.x < playerTransform.position.x)
        {
            attackOffsetX = -1f;
            TeleportDebug(false);

        }
        else if (transform.position.x > playerTransform.position.x)
        {
            attackOffsetX = 1f;
            TeleportDebug(true);
        }
        Vector2 attackOffset = new Vector2(attackOffsetX, 0f);

        updatedTargetPosition = new Vector2(playerTransform.position.x + attackOffset.x, 0f);
        transform.position = Vector3.MoveTowards(transform.position, updatedTargetPosition, speed * Time.deltaTime);
        //debugCircle.transform.position = updatedTargetPosition;
    }

    void LookAtPlayer()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void ChooseAttack()
    {
        distance = Vector3.Distance(transform.position, playerTransform.position);



        if (distance <= distanceBeforeHeavyAttack)
        {
            //enemyAnimator.SetTrigger("HeavyAttack"); // Heavy attack animation
            //print("HEAVY ATTACK");
            AttackPlayer(distanceBeforeHeavyAttack, "HeavyAttack"); // Call with appropriate range
            return; // Exit after heavy attack selection
        }

        if (distance <= distanceBeforeLightAttack)
        {
            //enemyAnimator.SetTrigger("LightAttack"); // Light attack animation
            //print("LIGHT ATTACK");
            AttackPlayer(distanceBeforeLightAttack, "LightAttack"); // Call with appropriate range
        }
    }

    void AttackPlayer(float attackRange, string attackType) // Updated function with range parameter
    {


        if (!isTeleporting && Vector3.Distance(transform.position, playerTransform.position) < attackRange)
        {
            if (Time.time > nextAttackTime) // Check for attack cooldown
            {
                print("CAN ATTACK - " + attackType);
                print(isTeleporting);
                nextAttackTime = Time.time + attackCooldownTime;
                //enemyAnimator.SetBool("IsRange", true);
            }
            else
            {
                //enemyAnimator.SetBool("IsRange", false);
            }
        }
    }

    void DealLightAttackDamage()
    {
        healthSystem.PlayerDamage(5f);
    }

    void DealHeavyAttackDamage()
    {
        healthSystem.PlayerDamage(10f);
    }
}