using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBehavior : MonoBehaviour
{
    //upon approaching this NPC, if the player hits Return, will set the quest the player is currently
    //on to "complete" via changing the related QuestInt to 1, and send the player back to the hub.
    //also writes that QuestInt's value to the file to "save" the player's progress
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.Return))
        {
            //ASCIILevelLoader.loaderInstance.CurrentLevel++;
            if (SceneManager.GetActiveScene().name == "Reality")
            {
                //GameManager.instance.RealityQuestDone = true;
                GameManager.instance.RealityQuestInt = 1;
                string realityFileContents = GameManager.instance.RealityQuestInt + "";
                File.WriteAllText(GameManager.instance.REALITY_FILE_PATH, realityFileContents);
            } 
            else if (SceneManager.GetActiveScene().name == "Ideals")
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
