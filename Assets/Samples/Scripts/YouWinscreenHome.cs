using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinUI : MonoBehaviour
{
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Home"); // Replace "Home" with your home scene name
    }
}

