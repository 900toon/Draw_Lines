using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextHolder : MonoBehaviour
{
    [SerializeField] private ScoreRecorder scoreRecorder;
     
    //inGameOverMenuUI 
    [SerializeField] private TextMeshProUGUI enemyKilled;
    [SerializeField] private TextMeshProUGUI timeSurvived;

    private void SetEnemyKilledText()
    {
        enemyKilled.text = $"Enemy Killed:      000000";
    }
    private void SetTimeSurvivedText()
    {
        int survivalTimeInInt = scoreRecorder.GetSurvivalTime();
        string floatPart;
        if (survivalTimeInInt % 60 < 10)
        {
            floatPart = $"0{survivalTimeInInt % 60}";   
        }
        else
        {
            floatPart = $"{survivalTimeInInt % 60}";
        }

        timeSurvived.text = $"Time Survived:      {survivalTimeInInt/60}  : {floatPart}";
    }        
    private void HandleInGameOverUI()
    {
        if (GameManager.gameState == GameManager.GameState.inGameOver)
        {
            SetEnemyKilledText();
            SetTimeSurvivedText();
        }
    }
    private void Update()
    {
        HandleInGameOverUI();
    }

}
