using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public CircleCollider2D portalCollider;
    public SpriteRenderer portalSprite;
    
    // sets the portal to be inactive by default
    void Start()
    {
        portalCollider = GetComponent<CircleCollider2D>();
        portalSprite = GetComponent<SpriteRenderer>();

        portalCollider.enabled = false;
        portalSprite.enabled = false;
        
    }

    // if both quests are done, activates the portal object so the player can interact with it
    void Update()
    {
        if (GameManager.instance.IdealsQuestDone == true && GameManager.instance.RealityQuestDone == true)
        {
            portalCollider.enabled = true;
            portalSprite.enabled = true;
            
        }
    }

    //sends the player to the EndScene scene when they touch the portal
    private void OnTriggerStay2D(Collider2D other)
    {
        SceneManager.LoadScene("EndScene");
    }
}
