using TMPro;
using UnityEngine;

public class SnowMover : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 originalPosition;
    private Vector3 target;
    private bool isMovingToTarget = false;
    public GameObject gun_lookat;

    public void Start()
    {
        originalPosition = transform.position;
        target = originalPosition;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMovingToTarget)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            isMovingToTarget = true;

            // Calculate the direction to the target
            Vector3 directionToTarget = target - gun_lookat.transform.position;
            directionToTarget.z = 0f; // Set the z component to zero to ignore it

            // Calculate the rotation angle in radians
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            // Apply the rotation only to the z-axis
            gun_lookat.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        if (isMovingToTarget)
        {
            MoveToTarget();
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            isMovingToTarget = false;
        }
    }

    private void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
    }

}
