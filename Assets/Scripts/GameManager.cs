using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    public int totalPoints = 0;

//    public float startTime;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this; // Set Instance on Awake
//        }
//        else
//        {
//            Destroy(gameObject); // Destroy duplicate GameManagers
//        }

//        DontDestroyOnLoad(gameObject); // Persist across scenes
//    }

//    private void Start()
//    {
//        startTime = Time.time;
//    }

//    private void Update()
//    {
//        CalculateScore();
//    }


//    void CalculateScore()
//    {
//        float endTime = Time.time;
//        float elapsedTime = endTime - startTime;

//        // Example: Award points based on a threshold (adjust values as needed)
//        int baseScore = 500;
//        float timePenalty = 1f; // Points deducted per second

//        if (elapsedTime <= 5.0f)
//        { // Bonus for fast completion
//            totalPoints = baseScore + 50;
//        }
//        else
//        {
//            totalPoints = Mathf.RoundToInt(baseScore - (elapsedTime - 5.0f) * timePenalty);
//        }

//        // Ensure score doesn't go negative
//        totalPoints = Mathf.Max(totalPoints, 50);
//    }


//    public void AddPoints(int _points)
//    {
//        totalPoints = totalPoints + _points;
//    }
//}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalPoints = 0; // Total accumulated points, including time bonus
    public int timeBasedScore; // Stores the calculated time-based score

    private float startTime;

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

    public void AddPoints(int _points) // Function to add points
    {
        totalPoints += _points;  // Directly add points to total score
    }

    // Call this function only when the level is completed
    public void CalculateTimeBasedScore()
    {
        float endTime = Time.time;
        float elapsedTime = endTime - startTime;

        // Example: Award points based on a threshold (adjust values as needed)
        int baseScore = 500;
        float timePenalty = 1f; // Points deducted per second

        if (elapsedTime <= 5.0f)
        { // Bonus for fast completion
            timeBasedScore = baseScore + 50;
        }
        else
        {
            timeBasedScore = Mathf.RoundToInt(baseScore - (elapsedTime - 5.0f) * timePenalty);
        }

        // Ensure score doesn't go negative
        timeBasedScore = Mathf.Max(timeBasedScore, 50);
    }

    // Call this in LevelCompleted function or similar to add time bonus
    public void AddTimeBonus()
    {
        totalPoints += timeBasedScore; // Add the calculated time-based score
    }
}
