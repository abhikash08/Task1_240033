using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public Transform player;          // Drag your player here in the Inspector
    public Vector2 winPosition = new Vector2(36.9f, -9.2f); // Set desired win coordinate
    public float tolerance = 0.5f;    // Allow small error range

    public string winSceneName = "YouWin"; // Match the exact scene name

    void Update()
    {
        if (Vector2.Distance(player.position, winPosition) <= tolerance)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}

