using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHolder : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject monsterPrefab;

    public event EventHandler OnClearAllMonsters;
    private List<GameObject> monsters;
    [SerializeField] private float safeArea = 50f;
    private float countTime = 0;
    [SerializeField] private float SpanwTimeInterval = 5f;

    public void ClearAllMonsters()
    {
        OnClearAllMonsters?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
       
        CheckState();
    }

    private void CheckState()
    {
        if (GameManager.gameState == GameManager.GameState.inGame)
        {
            countTime += Time.deltaTime;
            if (IsAbleToSpawn()) RandomlySpawnMonster();
        }
        
    }

    private void RandomlySpawnMonster()
    {
        
        Vector3 spawnPosition = RandomSpawnPosition();
        
        
        GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.Euler(0, 0, 0), gameObject.transform);
        countTime = 0;
        /*Debug.Log("spawn monster");
        Debug.Log(spawnPosition);*/
    }

    private Vector3 RandomSpawnPosition()
    {
        while (true) 
        {
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-safeArea * 2, safeArea * 2), UnityEngine.Random.Range(-safeArea * 2, safeArea * 2), 0);
            if (Math.Abs(spawnPosition.x) > safeArea || Math.Abs(spawnPosition.y) > safeArea)
            {
                return spawnPosition;
            }
        }
        
        
    }

    private bool IsAbleToSpawn()
    {
        if (countTime > SpanwTimeInterval) return true;
        else return false;
        
    }
}
