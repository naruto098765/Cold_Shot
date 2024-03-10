using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public List<GameObject> hidingObjects; // List to hold hiding objects
    public GameObject gameOverPanel; // Reference to the game over panel

  //  private int enemyCollisions = 0; // Counter for enemy collisions

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Check if there are hiding objects left
            if (hidingObjects.Count > 0)
            {
                // Hide one object from the list
                GameObject objectToHide = hidingObjects[0];
                hidingObjects.RemoveAt(0);
                objectToHide.SetActive(false);
            }
            else
            {
                Debug.Log("Panel Displayed");
                // Display game over panel if the list is empty
                gameOverPanel.SetActive(true);
            }
        }
    }


}
