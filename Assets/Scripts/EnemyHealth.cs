using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;

    public float enemyHealth;

    Animator anim;

    private void Start()
    {
        enemyHealth = maxHealth;
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
             anim.Play("Enemy-Death");
             float deathAnimLenght = 0.3f;
             Invoke("DisableEnemy", deathAnimLenght);

            
        }
    }
    public void EnemyDamage(float damagePoints)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damagePoints;
        }
    }

    public void DisableEnemy()
    {
        this.gameObject.SetActive(false);
    }
}
