using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRegularHurtBox : MonoBehaviour
{

    [SerializeField] private GameObject monsterGameObject;
    private MonsterRegular monsterRegular;
    private const int THREAD_AND_NODE_LAYER_CODE = 6;
    private const int PLAYER_LAYER_CODE = 9;

    private void Start()
    {
        monsterRegular = monsterGameObject.GetComponent<MonsterRegular>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == THREAD_AND_NODE_LAYER_CODE)
        {
            var colliderScript = collision.gameObject.GetComponent<ThreadHitBox>().GetParentScript();
            monsterRegular.TakeDamage(2f);
        }

    }

}
