using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bomb_touch : MonoBehaviour
{
    public float y_distance = -5f; // Distance to move the object upwards
    public GameObject GameOverPanel;
    

    // This method is called when the mouse is clicked on the object
    private void OnMouseDown()
    {

        Debug.Log("Bomb touched");

        // Increment the score by 1


        // Update the score text

        GameOverPanel.SetActive(true);
        // Move the current enemy downward
        transform.Translate(0f, y_distance, 0f);
    }

    // Method to increment the score
   
   
}