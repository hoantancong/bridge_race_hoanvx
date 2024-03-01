using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI levelText;
    public void OnPausedGame()
    {
        GameManager.Instance.PausedGame();
    }
    private void OnEnable()
    {
        levelText.text = $"Level {GameManager.Instance.gameLevel}";
    }
}
