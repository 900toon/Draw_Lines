using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int healthPoint = 3;
    [SerializeField] private MonsterHolder monsterHolder;

    private void Update()
    {
        CheckState();
    }
    public Vector3 GetTransformPosition()
    {
        return transform.position;
    }

    public void TakeDamage()
    {
        healthPoint -= 1;
        ClearScreenWhileGetHurt();
        PlayerLoseHealth();
    }

    private void ClearScreenWhileGetHurt()
    {

        monsterHolder.ClearAllMonsters();
    }

    private void CheckState()
    {
        if (GameManager.gameState == GameManager.GameState.inGame) 
        {
            if (!IsPlayerAlive()) GameManager.GameOver();
        }
    }

    private bool IsPlayerAlive()
    {
        if (healthPoint <= 0) return false;
        else return true;
    }

    public event EventHandler<OnPlayerLoseHealthPointEventArgs> OnPlayerLoseHealthPoint;
    public class OnPlayerLoseHealthPointEventArgs: EventArgs
    {
        public int healthPoint;
    }
    private void PlayerLoseHealth()
    {
        OnPlayerLoseHealthPoint?.Invoke(this, new OnPlayerLoseHealthPointEventArgs() {healthPoint = this.healthPoint});
    }

}

