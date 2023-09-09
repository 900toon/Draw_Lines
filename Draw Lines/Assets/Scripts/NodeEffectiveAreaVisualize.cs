using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffectiveAreaVisualize : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NodesController nodesController;
    [SerializeField] private GameObject[] effectiveVertices;

    private void Start()
    {
        effectiveAreaVertexShow_ForTesting();
    }
    private void effectiveAreaVertexShow_ForTesting()
    {
        float effectiveAreaLengthX = nodesController.GetNodesEffectiveAreaLength_XandY()[0];
        float effectiveAreaLengthY = nodesController.GetNodesEffectiveAreaLength_XandY()[1];

        effectiveVertices[0].transform.position = new Vector3(effectiveAreaLengthX, effectiveAreaLengthY, 0);
        effectiveVertices[1].transform.position = new Vector3(-effectiveAreaLengthX, effectiveAreaLengthY, 0);
        effectiveVertices[2].transform.position = new Vector3(-effectiveAreaLengthX, -effectiveAreaLengthY, 0);
        effectiveVertices[3].transform.position = new Vector3(effectiveAreaLengthX, -effectiveAreaLengthY, 0);
    }
}
