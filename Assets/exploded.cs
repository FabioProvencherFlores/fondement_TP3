using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploded : MonoBehaviour
{
    public float hitBoxRadius = 1.5f;
    public GameObject explosionPrefab;
    public GameObject gameManager;
    public int pointsPike = 100;
    public int pointsBomb = 50;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        Destroy(gameObject, 5f);
        Instantiate(explosionPrefab, transform);
        Collider2D[] objectExploded = Physics2D.OverlapCircleAll(gameObject.transform.position,hitBoxRadius);

        for (int i = 0; i<objectExploded.Length; i++)
        {
            if (objectExploded[i].tag != "Player")
            {
                if (objectExploded[i].tag == "pike")
                {
                    gameManager.GetComponent<GameManager>().addPoints(pointsPike);
                }
                else if (objectExploded[i].tag == "bomb")
                {
                    gameManager.GetComponent<GameManager>().addPoints(pointsBomb);
                }
                Destroy(objectExploded[i].gameObject);
            }
        }
    }
}
