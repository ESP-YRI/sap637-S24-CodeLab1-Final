using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortalBehavior : MonoBehaviour
{
    //when the player touches a portal within an ascii level, it increments the currentLevel integer
    //and loads the next level
    private void OnTriggerStay2D(Collider2D other)
    {
        ASCIILevelLoader.loaderInstance.CurrentLevel++;
        ASCIILevelLoader.loaderInstance.LoadLevel();
    }
}
