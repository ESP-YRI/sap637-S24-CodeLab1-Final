using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    public float forceAmt = .5f;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Moves the player upon presses of W A S or D keys
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.AddForce(Vector2.up * forceAmt);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(Vector2.left * forceAmt);
            playerSprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(Vector2.down * forceAmt);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector2.right * forceAmt);
            playerSprite.flipX = true;
        }

        playerRb.velocity *= .75f;
    }
}
