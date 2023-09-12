using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private NodesController nodesController;
    [SerializeField] private MonsterHolder monsterHolder;
    private float cameraSize = 100f;


    public static GameState gameState = new GameState();

    private const int MAIN_SCENE_CODE = 0;
    private const int FIRST_LEVEL_SCENE_CODE = 1;
    public enum GameState
    {
        inMainMenu,
        inGame,
        inGamePause,
        inGameOver,
        inGameComplete,
        inLevelChoose,
    }
    
   
    public static void SetGameState(GameState state)
    {
        gameState = state;
    }
    public static void LoadGame()
    {
        gameState = GameState.inGame;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(FIRST_LEVEL_SCENE_CODE);
        Debug.Log("GAME MANAGER: load in game");
    }

    public static void ReloadGame()
    {

    }
    public static void GameOver()
    {
        gameState = GameState.inGameOver;
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public static void LoadMainMenu()
    {
        gameState = GameState.inMainMenu;
        SceneManager.LoadScene(MAIN_SCENE_CODE);
    }

    public float GetCameraSize()
    {
        return cameraSize;
    }

    private void Start()
    {
        Debug.Log("game manager start");
    }

}
