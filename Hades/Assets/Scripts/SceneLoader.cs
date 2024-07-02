using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class SceneLoader 
{
    public enum Scene {
        Game, GeneralMenu
    }
    public static void Load(Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }

}
