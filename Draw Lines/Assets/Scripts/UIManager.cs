using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inGamePauseCanvas;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject inGameOverCanvas;

    private void Update()
    {
        HandleInGameUI();
    }
    private void HandleInGameUI()
    {
        switch (GameManager.gameState)
        {
            case GameManager.GameState.inGamePause:
                inGameCanvas.SetActive(false);
                inGamePauseCanvas.SetActive(true);
                inGameOverCanvas.SetActive(false);
                break;

            case GameManager.GameState.inGame:
                inGameCanvas.SetActive(true);
                inGamePauseCanvas.SetActive(false);
                inGameOverCanvas.SetActive(false);
                break;

            case GameManager.GameState.inGameOver:
                inGameCanvas.SetActive(false);
                inGamePauseCanvas.SetActive(false);
                inGameOverCanvas.SetActive(true);
                break;

        }
            
    }

    public void Pause()
    {
        GameManager.SetGameState(GameManager.GameState.inGamePause);
        GameManager.Pause();
    }

    public void Resume()
    {
        GameManager.SetGameState(GameManager.GameState.inGame);
        GameManager.Resume();
    }

    public void BackToMainMenu()
    {
        GameManager.SetGameState(GameManager.GameState.inMainMenu);
    }

    public void MainMenu_LoadInGame()
    {
        Debug.Log("MENU:  load in game");
        GameManager.LoadGame();
    }

    
}
