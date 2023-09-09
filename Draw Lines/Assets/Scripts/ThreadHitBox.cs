using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadHitBox : MonoBehaviour
{
    [SerializeField] private Thread thread;
    public Thread GetParentScript()
    {
        //return the parent script
        return thread;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
