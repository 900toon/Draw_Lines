using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thread : MonoBehaviour
{

    [SerializeField] private float damagePoint = 2f;
    private void Start()
    {
        
    }
    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }

    public float GetDamagePoint()
    {
        return damagePoint;
    }
    
}
