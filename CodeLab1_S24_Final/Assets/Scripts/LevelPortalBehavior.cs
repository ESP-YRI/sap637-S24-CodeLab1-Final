using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortalBehavior : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ASCIILevelLoader.loaderInstance.CurrentLevel++;
            ASCIILevelLoader.loaderInstance.LoadLevel();
        }
    }
}
