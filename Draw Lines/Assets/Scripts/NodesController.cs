using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class NodesController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject nodePointPrefab;

    [SerializeField] private float effectiveAreaLengthX = 50f;
    [SerializeField] private float effectiveAreaLengthY = 60f;

    private List<GameObject> nodesList;


    private int nodesMaxAmount = 3;
    private void Start()
    {
        inputManager.OnTouchPositionGet += GetTouched_OnTouchPositionGet;
        nodesList = new List<GameObject>(); 
    }
    private void Update()
    {
        NodesListClean();
        SetNodesList();

    }

    private void GetTouched_OnTouchPositionGet(object sender, InputManager.OnTouchPositionGetEventArgs e)
    {
        if (GameManager.gameState == GameManager.GameState.inGame) CreateNewNode(e.touchPositionVector3);
    }

    private void CreateNewNode(Vector3 newPosition)
    {
        if (EffectiveAreaCheck(newPosition))
        {
            if (nodesList.Count < nodesMaxAmount)
            {
                GameObject currentNode = Instantiate(nodePointPrefab, gameObject.transform);
                currentNode.transform.position = newPosition;
                nodesList.Add(currentNode);
            }
        }        
    }
    private void NodesListClean()
    {

        foreach (GameObject node in nodesList)
        {
            if (node == null)
            {
                nodesList.Remove(node);
                break;
            }
        }
        if (nodesList.Count != 0) nodesList[0].GetComponent<ThreadNode>().SetAsFirstNode();
    }

    private void SetNodesList()
    {
        for (int i = 0; i < nodesList.Count; i++)
        {
            ThreadNode currentNode = nodesList[i].GetComponent<ThreadNode>();

            //if current node is the first node, set the previous node to null
            if (currentNode.IsFirstNode())
            {
                currentNode.SetPreviousNodeNull();
            }
            //else give it the previous node
            else
            {
                if (!currentNode.HasPreviousNode()) currentNode.SetPreviousNode(nodesList[i-1]);
            }
        }
    }

    
    private bool EffectiveAreaCheck(Vector3 positionGot)
    {
        if (positionGot.x <= effectiveAreaLengthX && positionGot.x >= -effectiveAreaLengthX)
        {
            if (positionGot.y <= effectiveAreaLengthY && positionGot.y >= -effectiveAreaLengthY)
            {
                return true;
            }
        }

        return false;
    }

    public float[] GetNodesEffectiveAreaLength_XandY()
    { 
        return new float[2]{ effectiveAreaLengthX, effectiveAreaLengthY };
    } 

}
