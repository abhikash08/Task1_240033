using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play button calls this
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    // Exit button calls this
    public void ExitGame()
    {
        Application.Quit();
        
        // Editor-specific quit (optional but helpful)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
