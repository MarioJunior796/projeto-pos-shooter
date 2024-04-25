using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerPoint : MonoBehaviour
{
    public float minY = -4.52f, maxY = 4.24f;
    public float timer = 2f;

    public GameObject[] asteroidPrefab;
    public GameObject enemyPrefab;

    void Start()
    {
        Invoke("SpawnEnemies", timer);
    }

    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        float posY = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = posY;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 0f));
        }

        Invoke("SpawnEnemies", timer);
    }
}
