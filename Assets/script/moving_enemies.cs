using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_enemies : MonoBehaviour
{
    public float speed = 5f; // Speed at which the enemy moves to the right
    public float amplitude = 1f; // Amplitude of the wave
    public float frequency = 1f; // Frequency of the wave
    public GameObject enemyTouchObject; // Reference to the GameObject containing the Enemy_touch script

    private float initialY; // Initial Y position
    private Vector3 initialPosition; // Initial position

    // Reference to the Enemy_touch script
    private Enemy_touch enemyTouchScript;
   // public int score = 3;
  //  public List<GameObject> enem; // List of objects to check for collision
   // public GameObject hd;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position
        initialPosition = transform.position;
        // Store the initial Y position
        initialY = transform.position.y;

        // Get the Enemy_touch script component from the GameObject
        enemyTouchScript = enemyTouchObject.GetComponent<Enemy_touch>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy to the right
        float newX = transform.position.x + speed * Time.deltaTime;
        float newY = initialY + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            score--;
            hd.SetActive(false);
            Debug.Log("Collision with Block! Score: " + score);
        }
    }*/

    // Method called when the mouse button is clicked
    private void OnMouseDown()
    {
        // Reset the position to the initial position
        transform.position = initialPosition;

        // Update the score from the Enemy_touch script
        if (enemyTouchScript != null)
        {
            // Increment the score
            enemyTouchScript.IncrementScore();

            // Update the score text
            if (enemyTouchScript.scoreText != null)
            {
                enemyTouchScript.scoreText.text = "Hit: " + Enemy_touch.score.ToString() + "/10"; // Access score statically
            }
        }
    }
}
