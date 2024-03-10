using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text object for displaying the score
    private static int score = 0; // Static score variable to track the score across all instances

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Check if the ray hit any collider
            if (hit.collider == null)
            {
                Debug.Log("decrease");
                // If no collider is hit, decrement the score
                DecrementScore();
            }
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    // Method to decrement the score
    public void DecrementScore()
    {
        
            score--;
            UpdateScoreText();
        
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
