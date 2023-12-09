using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGrid : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Material[] materials = new Material[2];
    [SerializeField] private int rows;
    [SerializeField] private int columns;

    private void Start()
    {
        Create();
    }
    public void Create()
    {
        while(transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);

        var customGrid = new GameObject("CustomGrid");
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                var gridPoint = new GameObject(i + " " + j);
                gridPoint.transform.parent = customGrid.transform;
                var meshRenderer = gridPoint.AddComponent<MeshRenderer>();
                gridPoint.AddComponent<MeshFilter>();
                gridPoint.GetComponent<MeshFilter>().mesh = obstacle.GetComponent<MeshFilter>().sharedMesh;

                if((i + j) % 2 == 0)
                    meshRenderer.material = materials[0];
                else
                    meshRenderer.material = materials[1];

                gridPoint.transform.localPosition = new Vector3(i, 0f, j);
            }
        }
        customGrid.transform.parent = transform;
        customGrid.transform.localPosition = new Vector3(0, 0, 0);
    }
}
