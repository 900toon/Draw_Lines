using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{
    private int monsterKilledNumber = 0;
    private float survivalTime = 0f;

    private void Update()
    {
        CountSurvivalTime();
    }

    public void AddOnePointToMonsterKilledNumber()
    {
        monsterKilledNumber++;
        Debug.Log(monsterKilledNumber);
    }

    private void CountSurvivalTime()
    {
        if (GameManager.gameState == GameManager.GameState.inGame)
        {
            survivalTime += Time.deltaTime;
        }
    }

    public int GetMonsterKilledNumber()
    {
        return monsterKilledNumber;
    }

    public int GetSurvivalTime()
    {
        return (int)Mathf.Floor(survivalTime);
    }

    public int GetCoinNumber()
    {
        
        return GetMonsterKilledNumber() * (1 + (GetSurvivalTime()/30));
    }
    
  
  

}
