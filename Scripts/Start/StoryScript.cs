using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript
{
    public void nextScene() {
        LoaderScript.Load(LoaderScript.Scene.WellScene);
    }
}
