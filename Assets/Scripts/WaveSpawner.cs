using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount;

    public GameObject Enemy;

    bool waveIsDone = true;

    void Update()
    {
        if(waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyClone = Instantiate(Enemy);

            yield return new WaitForSeconds(spawnRate);

        }

        spawnRate -= 0.1f;
        enemyCount += 3;
        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
}
