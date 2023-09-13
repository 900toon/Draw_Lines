using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmGoBackToMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject confirmGoBackToMainMenuGameObject;
    public void GoBackToMainMenuYes()
    {
        GameManager.LoadMainMenu();
    }

    public void GoBackToMainMenuNo()
    {
        confirmGoBackToMainMenuGameObject.SetActive(false);   
    }
}
