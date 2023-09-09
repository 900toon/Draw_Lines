using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointVisual : MonoBehaviour
{
    [SerializeField] private GameObject healthPointFull;
    [SerializeField] private GameObject healthPointEmpty;
    public void SetHealthPointEmptyVisual()
    {
        healthPointFull.SetActive(false);
        healthPointEmpty.SetActive(true);
    }

    public void SetHealthPointFullVisual()
    {
        healthPointFull.SetActive(true);
        healthPointEmpty.SetActive(false);
    }
}
