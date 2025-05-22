using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public void RestartGame()
    {
        
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToHome()
    {
        
        SceneManager.LoadScene("Home");
    }
}
