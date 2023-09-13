using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelSelect;
    private const int SCENE_CODE_CONST_VALUE = 2;

    private void Start()
    {
        SetLevelText();
    }
    public void LoadLevel()
    {
        GameManager.SetGameState(GameManager.GameState.inGame);
        GameManager.LoadGame(levelSelect + SCENE_CODE_CONST_VALUE);
        

    }


    [SerializeField] private TextMeshProUGUI levelText;

    private void SetLevelText()
    {
        levelText.text = $"{levelSelect + 1}";
    }

    
}
