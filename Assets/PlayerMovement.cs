using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 5f;
    Vector2 movement;

    private bool canJump = true;
    public float jumpHauteur = 5f;
    private float jumpForce;
    public float jumpTimer = 1f;
    private float jumpRemainingTime;
    private bool jumping = false;
    public Transform bottomCollider;
    public LayerMask isFloor;

    public GameObject player;
    public LayerMask isEnemy;
    public LayerMask isBomb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (jumping)
        {
            if (jumpRemainingTime <= 0f)
            {
                jumping = false;
            }
            else
            {
                jumpRemainingTime -= Time.deltaTime;
            }
        }

        //check si une tuile 'plancher' est sous le joueur pour pouvoir sauter
        canJump = Physics2D.OverlapCircle(bottomCollider.position, 0.1f, isFloor);

        //check si le joueur saute sur un enemy ou une bombe
        if (Physics2D.OverlapCircle(bottomCollider.position, 0.2f, isEnemy))
        {
            player.GetComponent<PlayerHealth>().TakeDamage();
        }
        else if (Physics2D.OverlapCircle(bottomCollider.position, 0.2f, isBomb))
        {
            player.GetComponent<Explosion>().Kaboum();
        }
    }

    private void FixedUpdate()
    {
        if (movement.x != 0)
        {
            rb.position += movement * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump(1f);
        }

        if (jumping && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * (jumpForce - 1);
            jumpForce -= Time.deltaTime * jumpForce/jumpRemainingTime;
            //Debug.Log(jumpForce);
        }
        else
        {
            jumping = false;
            jumpForce = jumpHauteur;
        }
    }

    public void Jump(float force)
    {
        //force pousse plus haut when explosion
        jumpRemainingTime = jumpTimer;
        jumping = true;
        canJump = false;
        rb.velocity = Vector2.up * jumpHauteur*force;
    }
}
