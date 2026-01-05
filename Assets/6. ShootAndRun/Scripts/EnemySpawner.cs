using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
     
    private float xPosMax;
    private float yPosMax;
    private float spawnTimer;
    private float spawnTimerMax = 2f;
    private int number = 0;
    

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTimerMax)
        {
            spawnTimer = 0;
            number++;

            float spawnXPos = 0;
            float spawnYPos = 0;
            while (spawnXPos >= 0 && spawnYPos >= 0 && spawnXPos <= 1 && spawnYPos <= 1)
            {
                spawnXPos = Random.Range(-0.2f, 1.2f);
                spawnYPos = Random.Range(-0.2f, 1.2f);
            }
            Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(spawnXPos, spawnYPos));
            Transform enemyTransform = Instantiate(enemyPrefab, transform);
            enemyTransform.localPosition = spawnPos;
            enemyTransform.GetComponent<Enemy>().Faster(number);
        }
    }
}
