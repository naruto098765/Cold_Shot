using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private bool isPaused = false; // Flag to track whether the game is paused
    public GameObject pausepanel;

    // Start is called before the first frame update
    void Start()
    {
        pausepanel.SetActive(false);
    }

    // Method to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0; // Set the time scale to 0 to pause the game
        isPaused = true;
    }

    // Method to resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1; // Set the time scale back to 1 to resume the game
        isPaused = false;
        close_panel();
    }

    // Method to load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }


    public void close_panel()
    {
        pausepanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the game is paused
        if (isPaused)
        {
            // Implement any logic needed while the game is paused
            // For example, display a pause menu panel or overlay
            pausepanel.SetActive(true);
        }
        else
        {
            // Implement any logic needed while the game is running normally

        }
    }
}
