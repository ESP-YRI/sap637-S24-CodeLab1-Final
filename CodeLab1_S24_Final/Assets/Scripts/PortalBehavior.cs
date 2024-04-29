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
    
    // Start is called before the first frame update
    void Start()
    {
        portalCollider = GetComponent<CircleCollider2D>();
        portalSprite = GetComponent<SpriteRenderer>();

        portalCollider.enabled = false;
        portalSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IdealsQuestDone == true && GameManager.instance.RealityQuestDone == true)
        {
            portalCollider.enabled = true;
            portalSprite.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
