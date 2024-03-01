using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonManager<LevelManager>
{
    // Start is called before the first frame update
    private GameObject currentLevel;
    public void LoadNextLevel()
    {
        //load level
        //load player
    }
    //
    private IEnumerator LoadLevelAdditiveAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        // wait for load has finished
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        //load level done

    }
    public void LoadLevel(int levelNumber)
    {

        //unload old level if exits
        if (SceneManager.GetSceneByName($"Level{levelNumber - 1}").isLoaded)
        {
            SceneManager.UnloadSceneAsync($"Level{levelNumber - 1}").completed += (AsyncOperation operation) =>
            {
                Debug.Log("Unload scene");
                StartCoroutine(LoadLevelAdditiveAsync($"Level{levelNumber}"));

            };
        }
        else
        {
            StartCoroutine(LoadLevelAdditiveAsync($"Level{levelNumber}"));
        }

    }
    public void RestartLevel(int levelNumber)
    {
        if (SceneManager.GetSceneByName($"Level{levelNumber}").isLoaded)
        {
            SceneManager.UnloadSceneAsync($"Level{levelNumber}").completed += (AsyncOperation operation) =>
            {
                Debug.Log("Unload scene");
                StartCoroutine(LoadLevelAdditiveAsync($"Level{levelNumber}"));

            };
        }
    }
    //
}
