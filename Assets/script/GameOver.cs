using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over panel
    private int enemyCollisions = 0; // Counter for enemy collisions
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;

    // This method is called when a collision occurs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Increment the counter for enemy collisions
            enemyCollisions++;

            // Check if enemy collisions reach 3
            if (enemyCollisions >= 3)
            {
                // Display the game over panel
                if (gameOverPanel != null)
                {
                    gameOverPanel.SetActive(true);
                }
            }
            else
            {
                // Hide the appropriate object based on the number of collisions
                switch (enemyCollisions)
                {
                    case 1:
                        if (ob1 != null)
                            ob1.SetActive(false);
                        break;
                    case 2:
                        if (ob2 != null)
                            ob2.SetActive(false);
                        break;
                    case 3:
                        if (ob3 != null)
                            ob3.SetActive(false);
                        break;
                }
            }
        }
    }
}
