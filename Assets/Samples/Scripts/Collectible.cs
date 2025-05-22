using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollectible : MonoBehaviour
{
    public int scoreValue = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleManager.Instance.AddScore(scoreValue);
            Destroy(gameObject); // Optional: remove treasure box
        }
    }
}
