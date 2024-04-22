using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator bossAnimator;
    public float damagePoints;
    public HealthSystem healthSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("enemy hit " + this.gameObject.name);
            enemyAnimator.SetBool("IsAttackingRange", true);
            bossAnimator.SetBool("IsAttack", true);


            healthSystem.EnemyDamage(damagePoints);
            healthSystem.BossDamage(damagePoints);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            enemyAnimator.SetBool("IsAttackingRange", false);
            bossAnimator.SetBool("IsAttack", false);
    }
}
