using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public GameObject explosionCircle;
    public Transform playerPos;
    public GameObject player;
    public float explosionForce = 1.5f;


    public void Kaboum()
    {
        Debug.Log("Boom!");

        Instantiate(explosionCircle, playerPos);
        player.GetComponent<PlayerMovement>().Jump(explosionForce);

    }
}
