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
    private bool areTalking = false;
    public BoxCollider2D myTrigger;
    

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Ideals" && GameManager.instance.idealsQuestDone || 
            gameObject.tag == "Reality" && GameManager.instance.realityQuestDone)
        {
            myTrigger.enabled = false;
        }
        
        npcDialogue.Enqueue(assignedDialogue.line1);
        npcDialogue.Enqueue(assignedDialogue.line2);
        npcDialogue.Enqueue(assignedDialogue.line3);
        npcDialogue.Enqueue(assignedDialogue.line4);
        
        screenText.text = "(When you are near someone, press return to speak)";
    }

    // Update is called once per frame
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
                }
            }
        }
    }

    //when the player enters the hub NPC's trigger, they start saying their dialogue, and the
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
        }
    }
}
