using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASCIILoaderHelper : MonoBehaviour
{
    //this script's purpose is to allow the ascii level to be loaded upon entering an ascii level scene
    //since this is not a singleton, every time you enter a scene with an asciiloaderhelper in it,
    //it will run this code immediately, allowing the level to be loaded in
    void Start()
    {
        ASCIILevelLoader.loaderInstance.levelLoaded = false;
    }

}
