using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScript : MonoBehaviour
{
    public enum Scene
    {
        LoadingScene,
        StartMenuScene,
        WellScene,
        StartStoryScene,
        EndingScene
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }


    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
