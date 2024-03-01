using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnResume()
    {
        GameManager.Instance.ResumeGame();
    }
    public void OnRestart()
    {
        GameManager.Instance.RestartLevel();
    }
}
