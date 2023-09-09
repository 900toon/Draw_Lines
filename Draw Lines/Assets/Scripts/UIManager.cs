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
        HandleInGameCanvas();
        HandleInGamePauseCanvas();
        HandleInGameOverCanvas();
    }

    private void HandleInGamePauseCanvas()
    {
        if (GameManager.gameState == GameManager.GameState.inGamePause)
        {
            inGamePauseCanvas.SetActive(true);   
        }
        else
        {
            inGamePauseCanvas.SetActive(false);
        }
    }
    private void HandleInGameCanvas()
    {
        if (GameManager.gameState == GameManager.GameState.inGame)
        {
            inGameCanvas.SetActive(true);
        }
        else
        {
            inGameCanvas.SetActive(false);
        }
    }

    private void HandleInGameOverCanvas()
    {
        if (GameManager.gameState == GameManager.GameState.inGameOver)
        {
            inGameOverCanvas.SetActive(true);
        }
        else
        {
            inGameOverCanvas.SetActive(false);
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

    
}
