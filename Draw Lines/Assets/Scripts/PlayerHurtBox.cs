using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    private Player player;
    private const int MONSTER_LAYER_CODE = 7;

    private void Start()
    {
        player = playerGameObject.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == MONSTER_LAYER_CODE)
        {
            player.TakeDamage();
        }
    }
}
