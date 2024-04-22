using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("plus 10 points");
            GameManager.instance.AddPoints(10);
            this.gameObject.SetActive(false);
        }
    }
}
