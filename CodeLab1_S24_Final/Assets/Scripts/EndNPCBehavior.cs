using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndNPCBehavior : MonoBehaviour
{
    public Queue<String> npcDialogue = new Queue<string>();
    public DialogueScriptableObject assignedDialogue;
    public TextMeshProUGUI screenText;
    private bool areTalking = false;
    public GameObject yesButton;
    public GameObject noButton;
    
    void Start()
    {
        //Enqueues the given NPC's dialogue (stored in the DialogueScriptableObject) into a queue to be used later
        
        npcDialogue.Enqueue(assignedDialogue.line1);
        npcDialogue.Enqueue(assignedDialogue.line2);
        npcDialogue.Enqueue(assignedDialogue.line3);
        npcDialogue.Enqueue(assignedDialogue.line4);
    }

    void Update()
    {
        //if the player is talking with the npc, and hits enter, the dialogue progresses
        //when there is no more dialogue left, two buttons appear on screen for the player to click on
        if (areTalking == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (npcDialogue.Count > 1)
                {
                    npcDialogue.Dequeue();
                    screenText.text = npcDialogue.Peek();
                }
                else
                {
                    yesButton.SetActive(true);
                    noButton.SetActive(true);
                }
            }
        }
    }

    //when the player enters the end NPC's trigger, they start saying their dialogue, and the
    //areTalking bool is set to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            screenText.text = npcDialogue.Peek();
            areTalking = true;
        }
    }

    //when the player exits the hub npc's trigger, areTalking is set to false to prevent
    //dialogue from progressing 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            areTalking = false;
            screenText.text = "(Approach and Speak.)";
        }
    }
    
    //if the player clicks the "yes" button, they are transported to the true end scene
    public void YesButtonPress()
    {
        SceneManager.LoadScene("TrueEnd");
    }

    //if the player clicks the "no" button, they are transported to the title screen to play again
    public void NoButtonPress()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
