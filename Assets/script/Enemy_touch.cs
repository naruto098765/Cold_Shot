using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_touch : MonoBehaviour
{
    public float y_distance = -5f; // Distance to move the object upwards
    public static int score = 0; // Static score variable to track the score across all instances
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text object
    public int targetScore = 9; // Target score to trigger scene change

    // This method is called when the mouse is clicked on the object
    private void OnMouseDown()
    {
        Debug.Log("Enemy touched");

        // Increment the score by 1
        IncrementScore();

        // Update the score text
        scoreText.text = "Hit: " + score.ToString() + "/10";

        // Move the current enemy downward
        transform.Translate(0f, y_distance, 0f);

        // Check if the score reaches the target score
        if (score >= targetScore)
        {
            // Reset the score to 0s
            score = 0;

            // Load a new scene by its build index
            SceneManager.LoadScene(2); // Change the build index to the index of the scene you want to load
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
    }
}
