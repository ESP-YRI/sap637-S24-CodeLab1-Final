using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public SpriteRenderer spikeSprite;
    public float travelSpeed = .1f;

    private void Start()
    {
        spikeSprite = GetComponent<SpriteRenderer>();
    }

    //moves the spike slowly up or down
    private void Update()
    {
        transform.position -= new Vector3(0, travelSpeed, 0);
    }
    
    //if the player touches a spike, the level restarts
    //if the spike touches a block wall, it turns around and moves in the other direction
    //and flips its sprite so it's facing the right way as well
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ASCIILevelLoader.loaderInstance.LoadLevel();
        }
        else
        {
            travelSpeed *= -1;
            if (travelSpeed > 0)
            {
                spikeSprite.flipY = false;
            }
            else
            {
                spikeSprite.flipY = true;
            }
        }
    }
}
