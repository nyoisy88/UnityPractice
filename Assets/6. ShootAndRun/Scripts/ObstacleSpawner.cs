using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float xBorder = 20f;
    [SerializeField] private float yBorder = 20f;
    [SerializeField] private int numberOfObstacles = 100;

    void Start()
    {
        InstantiateObstacles();
    }

    void InstantiateObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            InstantiateObstacle();
        }
    }

    void InstantiateObstacle()
    {
        Vector3 randomPosition = GetRandomPosition();
        GameObject obstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity, transform);
        obstacle.transform.localScale = Vector3.one * Random.Range(1f, 2.5f);

        // Check for collisions and reposition if necessary
        while (CheckCollision(obstacle))
        {
            randomPosition = GetRandomPosition();
            obstacle.transform.localPosition = randomPosition;
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-xBorder, xBorder);
        float randomY = Random.Range(-yBorder, yBorder);

        return new Vector3(randomX, randomY, 0f);
    }

    bool CheckCollision(GameObject obstacle)
    {
        Collider2D obstacleCollider = obstacle.GetComponent<Collider2D>();

        // Define an area to check for collisions
        Vector2 checkPosition = obstacle.transform.position;
        Vector2 checkSize = obstacleCollider.bounds.size * 1.5f; // Adjust the multiplier as needed

        // Check for collisions within the area
        Collider2D[] colliders = Physics2D.OverlapBoxAll(checkPosition, checkSize, 0f);
        foreach (Collider2D collider in colliders)
        {
            // Skip self-collision
            if (collider.gameObject == obstacle)
                continue;

            // If any collision is detected, return true
            return true;
        }

        return false;
    }
}
