using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{

    //once the player hits enter, sends them to the first scene of the game: the hub world
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("HubScene");
        }
    }

    //when this function runs, it erases a player's progress by setting the contents of the 
    //files that store whether the player has completed a quest or not to 0, meaning "false"
    public void ResetProgress()
    {
        string idealsFileContents = 0 + "";
        string realityFileContents = 0 + "";
        File.WriteAllText(GameManager.instance.IDEALS_FILE_PATH, idealsFileContents);
        File.WriteAllText(GameManager.instance.REALITY_FILE_PATH, realityFileContents);
    }
}
