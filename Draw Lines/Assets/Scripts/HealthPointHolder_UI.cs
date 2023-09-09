using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointHolder_UI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] healthPointArray;

    private void Start()
    {
        player.OnPlayerLoseHealthPoint += OnPlayerLoseHealthPoint_VisualChanges;
    }

    private void OnPlayerLoseHealthPoint_VisualChanges(object sender, Player.OnPlayerLoseHealthPointEventArgs e)
    {
        /*Debug.Log(e.healthPoint);
        Debug.Log(healthPointArray[e.healthPoint]);*/
        healthPointArray[e.healthPoint].transform.GetComponent<HealthPointVisual>().SetHealthPointEmptyVisual();
    }

}
