using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public float speed = 5f; // Speed at which the object moves
    public float targetY = 5f; // Y position where the object should stop
    public float returnDelay = 3f; // Delay before returning to original position

    public List<Transform> enemies; // List to hold all enemy transforms

    private int currentEnemyIndex = 0; // Index of the enemy currently moving

    void Start()
    {
        // Shuffle the list of enemies randomly
        ShuffleList(enemies);
    }

    void Update()
    {
        // Move the current enemy if there are enemies left to move
        if (currentEnemyIndex < enemies.Count)
        {
            Transform currentEnemy = enemies[currentEnemyIndex];

            // Check if the current enemy has not reached the target Y position
            if (currentEnemy.position.y < targetY)
            {
                // Move the current enemy upward
                currentEnemy.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                // Stop updating the position of the current enemy
                currentEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                // Start the return coroutine
                StartCoroutine(ReturnToOriginalPosition(currentEnemy));

                // Move to the next enemy
                currentEnemyIndex++;
            }
        }
        else
        {
            // Reset the index when all enemies have moved
            currentEnemyIndex = 0;

            // Shuffle the list of enemies randomly for the next iteration
            ShuffleList(enemies);
        }
    }

    // Function to shuffle a list
    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // Coroutine to return the enemy to its original position after a delay
    private IEnumerator ReturnToOriginalPosition(Transform enemy)
    {
        Vector3 originalPosition = enemy.position;
        Vector3 targetPosition = originalPosition;
        targetPosition.y -= targetY; // Move to the original Y position

        float journeyLength = Vector3.Distance(enemy.position, targetPosition);
        float startTime = Time.time;

        while (enemy.position != targetPosition)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            enemy.position = Vector3.Lerp(enemy.position, targetPosition, fractionOfJourney);
            yield return null;
        }

        enemy.position = originalPosition;
    }

}
