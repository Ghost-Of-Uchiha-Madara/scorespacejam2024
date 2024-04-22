using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    //public Animator enemyAnimatior;
    public float damagePoints;
    public HealthSystem healthSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("enemy hit " + collision.gameObject.name);
            //enemyAnimatior.SetBool("IsAttackingRange", true);
            collision.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damagePoints);
            collision.transform.GetComponent<Animator>().SetBool("IsAttackingRange", true);
            //healthSystem.EnemyDamage(damagePoints);
        }

        if(collision.gameObject.CompareTag("Boss"))
        {
            healthSystem.BossDamage(damagePoints);
            collision.gameObject.GetComponent<Animator>().SetBool("IsAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Animator>().SetBool("IsAttackingRange", false);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("IsAttack", false);

        }
    }
}
