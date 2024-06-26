using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HubNPCBehavior : MonoBehaviour
{
    public Queue<String> npcDialogue = new Queue<string>();
    public DialogueScriptableObject assignedDialogue;
    public TextMeshProUGUI screenText;
    private bool areTalking = false;
    public Button yesButton;
    public Button noButton;
    
    void Start()
    {
        //Enqueues the given NPC's dialogue (stored in the DialogueScriptableObject) into a queue to be used later
        npcDialogue.Enqueue(assignedDialogue.line1);
        npcDialogue.Enqueue(assignedDialogue.line2);
        npcDialogue.Enqueue(assignedDialogue.line3);
        npcDialogue.Enqueue(assignedDialogue.line4);
        
        //The initial screen text for the hub
        screenText.text = "(Approach and speak)";
    }

    void Update()
    {
        //if the player is talking with the npc, and hits enter, the dialogue progresses
        //when there is no more dialogue left, the player is transported to the level scene
        //associated with the NPC in question
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
                    if (gameObject.tag == "Ideals")
                    {
                        SceneManager.LoadScene("Ideals");
                    }
                    else if (gameObject.tag == "Reality")
                    {
                        SceneManager.LoadScene("Reality");
                    }
                    else if (gameObject.tag == "Ending")
                    {
                        yesButton.enabled = true;
                        noButton.enabled = true;
                    }
                }
            }
        }

        if (GameManager.instance.IdealsQuestDone == true && GameManager.instance.RealityQuestDone == true)
        {
            screenText.text = "(A portal has opened... approach it and enter.)";
        }
    }

    //when the player enters the hub NPC's trigger, they start saying their dialogue, and the
    //areTalking bool is set to true
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Ideals" && GameManager.instance.IdealsQuestDone ||
                gameObject.tag == "Reality" && GameManager.instance.RealityQuestDone)
            {
                screenText.text = "(They have nothing more to teach you)";
            }
            else
            {
                screenText.text = npcDialogue.Peek();
                areTalking = true;
            }
        }
    }

    //when the player exits the hub npc's trigger, areTalking is set to false to prevent
    //dialogue from progressing 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            areTalking = false;
            screenText.text = "(Approach and Speak)";
        }
    }
}
