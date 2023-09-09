using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadNode : MonoBehaviour
{
    [SerializeField] private float existDuration = 5;
    private bool isFirstNode = false;

    [SerializeField] private GameObject firstNodeVisual;
    [SerializeField] private GameObject notFirstNodeVisual;

    private GameObject previousNode;
    [SerializeField] private GameObject threadPrefab;
    private GameObject thread;

    private void Update()
    {
        CheckState();
    }
    private void CheckState()
    {
        existDuration -= Time.deltaTime;
        if (existDuration < 0) SelfDestroy();

        HandleNodeMorph();
        HandleThread();
    }


    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void HandleNodeMorph()
    {
        if (!isFirstNode)
        {
            notFirstNodeVisual.SetActive(true);
            firstNodeVisual.SetActive(false);
        }
        else
        {
            notFirstNodeVisual.SetActive(false);
            firstNodeVisual.SetActive(true);
        }

    }

    

    public void SetAsFirstNode()
    {
        isFirstNode = true;
    }

    public bool IsFirstNode()
    {
        return isFirstNode;
    }

    public void SetPreviousNode(GameObject previousNode)
    {
        this.previousNode = previousNode;
    }

    public void SetPreviousNodeNull()
    {
        this.previousNode = null;
    }

    public bool HasPreviousNode()
    {
        return !(this.previousNode == null);
    }

    private void HandleThread()
    {
        
        if (thread == null && previousNode != null)
        {
            //thread belongs to the non previous node
            thread = Instantiate(threadPrefab, gameObject.transform);
            Vector3 threadOrientationVector = (previousNode.transform.position - transform.position);
            thread.transform.position = transform.position + threadOrientationVector / 2;
            thread.transform.rotation = GetRotationOfThread(threadOrientationVector);
            thread.transform.localScale = GetAdjustLengthOfThread(threadOrientationVector);
        }

        if (thread != null && previousNode == null)
        {
            thread.GetComponent<Thread>().DestroyItSelf();
        }
    }

    private Quaternion GetRotationOfThread(Vector3 inputVector)
    {
        Vector3 rotationInvector3;
        //vector exist only on x-axis or y-axis
        if (inputVector.x == 0)
        {
            rotationInvector3 = new Vector3(0, 0, 90);
        }
        else if (inputVector.y == 0)
        {
            rotationInvector3 = new Vector3(0, 0, 0);
        }
        else if (inputVector.x * inputVector.y > 0)
        {
            double theataInRad = Mathf.Atan((Mathf.Abs(inputVector.y)/Mathf.Abs(inputVector.x)));
            rotationInvector3 = new Vector3 (0, 0, (float)(theataInRad * 180 / Mathf.PI));
        }
        else
        {
            double theataInRad = Mathf.Atan((Mathf.Abs(inputVector.y) / Mathf.Abs(inputVector.x)));
            rotationInvector3 = new Vector3(0, 0, 180 - (float)(theataInRad * 180 / Mathf.PI));
        }


        return Quaternion.Euler(rotationInvector3);
    }

    private Vector3 GetAdjustLengthOfThread(Vector3 inputVector)
    {
        float adjustLength = Mathf.Sqrt((inputVector.x * inputVector.x) + (inputVector.y * inputVector.y));
        return new Vector3(adjustLength, 1, 0);
    }
}
