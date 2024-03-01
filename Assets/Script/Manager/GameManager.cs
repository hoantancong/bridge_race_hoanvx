using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    menu,
    gameplay,
    paused
}
public class GameManager : SingletonManager<GameManager>
{
    // Start is called before the first frame update
    public GameState gameState;
    public int gameLevel;
    void Start()
    {
        Time.timeScale = 0;
        gameState = GameState.menu;
        //gameLevel = PlayerPrefs.GetInt(Constants.GAME_KEY+"game_level",1);
        gameLevel = 1;
        UIManager.Instance.ShowUI(UIPanelType.MenuUI);
    }
    public void StartGame()
    {
        //change ui to game ui
        LevelManager.Instance.LoadLevel(gameLevel);
        //
        UIManager.Instance.ShowUI(UIPanelType.GameUI);
        Time.timeScale = 1.0f;
        gameState = GameState.gameplay;
    }
    public void PausedGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowUI(UIPanelType.PausedUI);
        gameState = GameState.paused;
    }
    public void ResumeGame()
    {
        UIManager.Instance.ShowUI(UIPanelType.GameUI);
        Time.timeScale = 1.0f;
        gameState = GameState.gameplay;
    }

    public void WinGame()
    {
        gameState = GameState.paused;
        //delay 1s
        UIManager.Instance.ShowUI(UIPanelType.WinUI);
    

    }
    public void LoseGame()
    {
        gameState = GameState.paused;
        //delay 1s
        UIManager.Instance.ShowUI(UIPanelType.LoseUI);
    }
    public void NextLevel()
    {
        gameLevel++;
        PlayerPrefs.SetInt(Constants.GAME_KEY + "game_level", gameLevel);
        LevelManager.Instance.LoadLevel(gameLevel);
        UIManager.Instance.ShowUI(UIPanelType.GameUI);
        Time.timeScale = 1.0f;
        gameState = GameState.gameplay;

    }
    public void RestartLevel()
    {
        LevelManager.Instance.RestartLevel(gameLevel);
        UIManager.Instance.ShowUI(UIPanelType.GameUI);
        Time.timeScale = 1.0f;
        gameState = GameState.gameplay;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
