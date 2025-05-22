using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ✅ Add this

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    public int currentScore = 0;
    public TMP_Text scoreText; // ✅ Changed from Text to TMP_Text

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "x " + currentScore;
        }
    }
}

