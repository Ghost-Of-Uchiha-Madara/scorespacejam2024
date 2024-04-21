using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public Animator enemyAnimatior;
    public float damagePoints;
    public HealthSystem healthSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("enemy hit " + this.gameObject.name);
            enemyAnimatior.SetBool("IsAttackingRange", true);

            healthSystem.EnemyDamage(damagePoints);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            enemyAnimatior.SetBool("IsAttackingRange", false);
    }
}
