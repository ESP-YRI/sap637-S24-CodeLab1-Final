using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu
    (
        fileName = "New Dialogue Script",
        menuName = "New Dialogue Script",
        order = 0
    )
]

//this scriptable object holds 4 strings, representing 4 lines of dialogue
public class DialogueScriptableObject : ScriptableObject
{
    public string line1;
    public string line2;
    public string line3;
    public string line4;
}
