using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnNextLevel()
    {
        GameManager.Instance.NextLevel();
    }
}
