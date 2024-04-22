using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalPoints = 0;

    public float startTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set Instance on Awake
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }

        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        CalculateScore();
    }

    
    void CalculateScore()
    {
        float endTime = Time.time;
        float elapsedTime = endTime - startTime;

        // Example: Award points based on a threshold (adjust values as needed)
        int baseScore = 1000;
        float timePenalty = 0.1f; // Points deducted per second

        if (elapsedTime <= 5.0f)
        { // Bonus for fast completion
            totalPoints = baseScore + 50;
        }
        else
        {
            totalPoints = Mathf.RoundToInt(baseScore - (elapsedTime - 5.0f) * timePenalty);
        }

        // Ensure score doesn't go negative
        totalPoints = Mathf.Max(totalPoints, 50);
    }
    

    public void AddPoints(int _points)
    {
        totalPoints = totalPoints + _points;
    }
}
