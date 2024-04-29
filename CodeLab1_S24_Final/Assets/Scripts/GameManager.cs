using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //file saving paths
    public string IDEALS_FILE_PATH;
    public string REALITY_FILE_PATH;
    const string FILE_DIR = "/Data/";
    const string idealsFileName = "idealsQuestCompletion.txt";
    const string realityFileName = "realityQuestCompletion.txt";

    //initializing two bools (and corresponding ints)
    //for checking if the two quests the player must complete before continuing 
    //the bools start false/ints start at 0, as you cannot have completed the quests before playing the game
    private bool idealsQuestDone = false;
    private int idealsQuestInt = 0;
    
    private bool realityQuestDone = false;
    private int realityQuestInt = 0;

    //sets + reads the integer associated with completion of the Ideals questline
    public int IdealsQuestInt
    {
        get
        {
            return idealsQuestInt;
        }

        set
        {
            //if the idealsQuestInt is 0, the quest is not completed, so the associated bool is set to false
            idealsQuestInt = value;
            if (idealsQuestInt == 0)
            {
                IdealsQuestDone = false;
            }
            //if it is 1, then the quest IS completed, thus the bool is set to true
            else if (idealsQuestInt == 1)
            {
                IdealsQuestDone = true;
            }
        }
    }
    
    //same as above, but for the Reality questline
    public int RealityQuestInt
    {
        get
        {
            return realityQuestInt;
        }

        set
        {
            realityQuestInt = value;
            if (realityQuestInt == 0)
            {
                RealityQuestDone = false;
            }
            else if (realityQuestInt == 1)
            {
                RealityQuestDone = true;
            }
        }
    }
    
    //reads the file associated with the Ideals quest's completion, and sets the idealsQuestDone bool
    //to false or true depending on whether the player has previously completed the quest
    public bool IdealsQuestDone
    {
        get
        {
            if (File.Exists(IDEALS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(IDEALS_FILE_PATH);
                idealsQuestInt = Int32.Parse(fileContents);
                if (idealsQuestInt == 0)
                {
                    idealsQuestDone = false;
                }
                else if (idealsQuestInt == 1)

                {
                    idealsQuestDone = true;
                }
            }
            return idealsQuestDone;
        }

        set
        {
            idealsQuestDone = value;
        }
    }
    
    //the same as above, but for the Reality questline
    public bool RealityQuestDone
    {
        get
        {
            if (File.Exists(REALITY_FILE_PATH))
            {
                string fileContents = File.ReadAllText(REALITY_FILE_PATH);
                realityQuestInt = Int32.Parse(fileContents);
                if (realityQuestInt == 0)
                {
                    realityQuestDone = false;
                }
                else if (realityQuestInt == 1)

                {
                    realityQuestDone = true;
                }
            }
            return realityQuestDone;
        }

        set
        {
            realityQuestDone = value;
        }
    }

private void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}

// Start is called before the first frame update
void Start()
{
    IDEALS_FILE_PATH = Application.dataPath + FILE_DIR + idealsFileName;
    REALITY_FILE_PATH = Application.dataPath + FILE_DIR + realityFileName;
}

// Update is called once per frame
void Update()
{

}
}
