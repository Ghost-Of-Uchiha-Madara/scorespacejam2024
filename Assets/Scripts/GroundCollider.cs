using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("END GAME");
            GameManager.instance.CalculateTimeBasedScore();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);  
        }
    }
}
