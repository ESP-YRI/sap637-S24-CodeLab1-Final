using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("HubScene");
        }
    }

    public void ResetProgress()
    {
        string idealsFileContents = 0 + "";
        string realityFileContents = 0 + "";
        File.WriteAllText(GameManager.instance.IDEALS_FILE_PATH, idealsFileContents);
        File.WriteAllText(GameManager.instance.REALITY_FILE_PATH, realityFileContents);
    }
}
