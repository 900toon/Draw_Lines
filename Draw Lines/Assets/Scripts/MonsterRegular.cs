using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRegular : MonoBehaviour
{
    private Player player;
    private const string PLAYER_GAMEOBJECT = "Player";
    private ScoreRecorder scoreRecorder;
    private const string SCORE_RECORDER_GAMEOBJECT = "ScoreRecorder";
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float healthPoint = 2f;
   

    private void Start()
    {
        player = GameObject.Find(PLAYER_GAMEOBJECT).GetComponent<Player>();
        scoreRecorder = GameObject.Find(SCORE_RECORDER_GAMEOBJECT).GetComponent<ScoreRecorder>();
        SubscribeToEventHandler();
    }
    private void Update()
    {
        HandleMovement();
        CheckState();
    }
    private void CheckState()
    {
        GetDestroyByHealthLost();
    }

    private void HandleMovement()
    {
        if (GameManager.gameState == GameManager.GameState.inGame) 
        {
            Vector3 moveDir = (player.GetTransformPosition() - transform.position).normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
        
    }

    public void TakeDamage(float damagePoint)
    {
        healthPoint -= damagePoint;
    }
    private void DestroyItself()
    {
        UnSubscribeToEventHandler();
        Destroy(gameObject);

    }
    private void SubscribeToEventHandler()
    {
        transform.parent.GetComponent<MonsterHolder>().OnClearAllMonsters += Monster_OnClearAllMonsters;
    }
    private void UnSubscribeToEventHandler()
    {
        transform.parent.GetComponent<MonsterHolder>().OnClearAllMonsters -= Monster_OnClearAllMonsters;
    }
    private void Monster_OnClearAllMonsters(object sender, EventArgs e)
    {
        DestroyItself();
    }

    private void GetDestroyByHealthLost()
    {
        if (healthPoint <= 0)
        {
            DestroyItself();
            scoreRecorder.AddOnePointToMonsterKilledNumber();
        }

        
    }

    
   

    
}
