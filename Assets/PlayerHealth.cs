using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;
    public int tempDamageValue = 1;
    public bool playerIsDead = false;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public void TakeDamage()
    {
        health -= tempDamageValue;

        if (health <= 0 && !playerIsDead)
        {
            PlayerDeath();
        }
    }

    private void Update()
    {
        if (transform.position.y <= -4.65f)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        playerIsDead = true;
        gameManager.GetComponent<GameManager>().GameOver();
    }
}
