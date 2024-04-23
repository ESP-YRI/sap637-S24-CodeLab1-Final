using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubNPCBehavior : MonoBehaviour
{
    public Queue<String> npcDialogue = new Queue<string>();
    public DialogueScriptableObject assignedDialogue;
    public TextMeshProUGUI screenText;
    private bool cooledDown = true;
    
    // Start is called before the first frame update
    void Start()
    {
        npcDialogue.Enqueue(assignedDialogue.line1);
        npcDialogue.Enqueue(assignedDialogue.line2);
        npcDialogue.Enqueue(assignedDialogue.line3);
        npcDialogue.Enqueue(assignedDialogue.line4);
        screenText.text = "(When you are near someone, press return to speak)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            screenText.text = "(Press return to speak with them)";
        }
    }
    */

    //when the player is close enough to the npc to talk to them (i.e. colliding with their trigger)
    //the first line of dialogue that that npc has will print on screen
    //if the player presses return, the dialogue will progress
    //because GetKey will read multiple inputs in the span of time that the button is held down,
    //thus speeding through all the dialogue, I added a cooldown of 1 so the player has time to stop pressing
    //before the game starts reading inputs again, so the dialogue won't zip through too fast
    private void OnTriggerStay2D(Collider2D other)
    {
        screenText.text = npcDialogue.Peek();
        if (other.tag == "Player" && Input.GetKey(KeyCode.Return) && cooledDown == true)
        {
            if (npcDialogue.Count > 0)
            {
                npcDialogue.Dequeue();
                cooledDown = false;
            }
            else
            {
                SceneManager.LoadScene("Ideals");
            }
            
            Invoke("CooldownDialogue", 1f);
        }
    }

    private void CooldownDialogue()
    {
        cooledDown = false;
    }
}
