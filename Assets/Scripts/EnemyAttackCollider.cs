using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    public HealthSystem healthSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.PlayerDamage(10f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
