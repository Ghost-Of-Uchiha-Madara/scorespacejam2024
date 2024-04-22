using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("END GAME");
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);  
        }
    }
}
