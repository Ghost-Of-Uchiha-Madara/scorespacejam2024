using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    public int hitPoint = 0;
    public Animator enemyAnimatior;
    private float health = 100f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("enemy hit " + this.gameObject.name);
            enemyAnimatior.SetBool("IsAttackingRange", true);
            hitPoint = hitPoint + 10;
            float currentHealth = health - hitPoint;
            print(currentHealth + " currentHealth");
            if(currentHealth < 0)
            {
                enemyAnimatior.SetBool("IsHaveHealth", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            enemyAnimatior.SetBool("IsAttackingRange", false);

    }
}
