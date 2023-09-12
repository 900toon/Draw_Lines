using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_MainMenu : MonoBehaviour
{
    public void LoadGame_ForTesting()
    {
        //this one is for testing
        Debug.Log("MENU:  load in game");
        GameManager.LoadGame();
    }
}
