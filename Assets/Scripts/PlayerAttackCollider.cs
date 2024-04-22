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
            print("enemy hit " + collision.gameObject.name);
            //enemyAnimatior.SetBool("IsAttackingRange", true);
            collision.gameObject.GetComponent<EnemyHealth>().EnemyDamage(damagePoints);
            collision.transform.GetChild(0).GetComponent<Animator>().SetBool("IsAttackingRange", true);
            //healthSystem.EnemyDamage(damagePoints);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetChild(0).GetComponent<Animator>().SetBool("IsAttackingRange", false);
        }
    }
}
