using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GameObject.FindObjectOfType<HealthSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            healthSystem.PlayerHeal(20f);
            this.gameObject.SetActive(false);
        }
    }
}
