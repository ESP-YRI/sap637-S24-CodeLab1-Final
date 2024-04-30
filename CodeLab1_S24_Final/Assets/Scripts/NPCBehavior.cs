using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBehavior : MonoBehaviour
{
    public Queue<String> npcDialogue = new Queue<string>();
    public DialogueScriptableObject assignedDialogue;
    private TextMeshProUGUI screenText;
    private bool areTalking = false;
    
    //Enqueues the given NPC's dialogue (stored in the DialogueScriptableObject) into a queue to be used later
    private void Start()
    {
        npcDialogue.Enqueue(assignedDialogue.line1);
        npcDialogue.Enqueue(assignedDialogue.line2);
        npcDialogue.Enqueue(assignedDialogue.line3);
        npcDialogue.Enqueue(assignedDialogue.line4);
        
        screenText = FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update()
    {
        //if the player is talking with the npc (areTalking bool is true), and hits enter, the dialogue progresses
        //when there is no more dialogue left, the player is transported to the hub again
        //and the fact that they completed a quest will be saved to a file (corresponding to which quest)
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
                    if (Input.GetKey(KeyCode.Return) && SceneManager.GetActiveScene().name == "Reality")
                    {
                        //GameManager.instance.RealityQuestDone = true;
                        GameManager.instance.RealityQuestInt = 1;
                        string realityFileContents = GameManager.instance.RealityQuestInt + "";
                        File.WriteAllText(GameManager.instance.REALITY_FILE_PATH, realityFileContents);
                    }
                    else if (Input.GetKey(KeyCode.Return) && SceneManager.GetActiveScene().name == "Ideals")
                    {
                        GameManager.instance.IdealsQuestDone = true;
                        GameManager.instance.IdealsQuestInt = 1;
                        string idealsFileContents = GameManager.instance.IdealsQuestInt + "";
                        File.WriteAllText(GameManager.instance.IDEALS_FILE_PATH, idealsFileContents);
                    }
                    SceneManager.LoadScene("HubScene");
                }
            }
        }
    }

    //upon approaching this NPC, if the player hits Return, will set the quest the player is currently
    //on to "complete" via changing the related QuestInt to 1, and send the player back to the hub.
    //also writes that QuestInt's value to the file to "save" the player's progress
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            screenText.text = npcDialogue.Peek();
            areTalking = true;
        }
    }
}

