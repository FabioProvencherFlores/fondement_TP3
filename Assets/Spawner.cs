using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPos;
    public GameObject[] enemy;

    public float spawnTimeMAx = 5f;
    public float spawnTimeMin = 3f;
    private float spawnRemainingTime = 0f;
    private int randomPos = 0; //stock la variable qui genere la position aleatoire
    private int randomEnemy = 0; //same mais pour enemy

    private int previousEnemy = 0;
    private int BackToBack = 0;

    private void Update()
    {
        if (spawnRemainingTime <= 0f)
        {
            spawnRemainingTime = Random.Range(spawnTimeMin, spawnTimeMAx); //reinitialise spawntime si zero a une valeur random
            SpawnEnemy();
        }

        else
            spawnRemainingTime -= Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        randomPos = Random.Range(0, spawnPos.Length);
        randomEnemy = Random.Range(0, enemy.Length);
        if (randomEnemy == previousEnemy)
        {
            BackToBack++;

            //check pour etre sur pas 4 enemie pareil de suite
            //les change si cest le cas
            if (BackToBack >= 4)
            {
                if (randomEnemy == 0)
                    randomEnemy = 1;
                else
                    randomEnemy = 0;
                BackToBack = 0;
                previousEnemy = randomEnemy;
            }
        }
        else
        {
            //reinitialise le conteur si des enemy sont different
            BackToBack = 0;
            previousEnemy = randomEnemy;
        }

        Instantiate(enemy[randomEnemy], spawnPos[randomPos]);
    }
}
