using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 7;
    

    [SerializeField] TextMeshProUGUI livesText;

    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

       
        if(numGameSessions >= 3)  
        {
            Destroy(gameObject);  
        } 
        else 
        {
            DontDestroyOnLoad(gameObject); 
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString(); 
             
    }

    public void ProcessPlayerDeath() // This is public. When John dies, he will call this.
    {
        if(playerLives > 1) 
        {
            playerLives--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            livesText.text = playerLives.ToString(); // if we change the value and we want UI to update
                                                     // we must do that manually
        }
        else // Game over.. need to start from the beginning
        {
            // Reset the ScenePersist
            SceneManager.LoadScene(0); // assume that scene 0 is the first one or the menu
            Destroy(gameObject); // Destroy the game session.
        }
    }
    
}
