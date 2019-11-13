using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float distanceBtwLayer = 1.5f;
    public Rigidbody2D rb;
    public bool startedLeft = true;
    private const int directionChanger = -1;
    private float startingPos;

    private void Start()
    {
        startingPos = gameObject.transform.position.x;

        if (transform.position.x > 0)
        {
            movementSpeed = movementSpeed * directionChanger;
        }
    }

    private void Update()
    {
        //detect if object has travelled the whole map
        //will pu it on higher layer and change its direction
        if (Mathf.Abs(startingPos - transform.position.x) >= 20)
        {
            transform.position = transform.position+ Vector3.up * distanceBtwLayer;
            startingPos = transform.position.x;
            movementSpeed = movementSpeed * directionChanger;

            //check if object is too high (genre above world map)
            if (transform.position.y >= 6f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.position += Vector2.right* movementSpeed * Time.deltaTime;
    }
}
