using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealthCollectible : MonoBehaviour
{
    public GameObject healthPrefab;

    public Transform[] healthSpawnPos;
    void Start()
    {
        InvokeRepeating("SpawnHealthPrefab", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnHealthPrefab()
    {
        int prefabPoint = Random.Range(0, healthSpawnPos.Length-1);
        Instantiate(healthPrefab, healthSpawnPos[prefabPoint]);
    }
}
