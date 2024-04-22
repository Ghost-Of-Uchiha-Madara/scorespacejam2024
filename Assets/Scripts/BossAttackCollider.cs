using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackCollider : MonoBehaviour
{
    public HealthSystem healthSystem;
    public float hitPoints;
    public Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.PlayerDamage(hitPoints);
            playerAnimator.SetBool("IsAttack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAnimator.SetBool("IsAttack", false);
        }
    }
}
