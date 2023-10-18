using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Celso_LevelInstantiator : MonoBehaviour
{
    [SerializeField] public GameObject edgeBoard;
    [SerializeField] private static int _lvlScale = 5;
    [SerializeField] private int[,] _mapReference;
    private int[] _upperEdge = new int[_lvlScale];
    private int[] _lowerEdge = new int[_lvlScale];
    private int[] _leftEdge = new int[_lvlScale];
    private int[] _rightEdge = new int[_lvlScale];


    private void Awake()
    {
        _mapReference = new int[_lvlScale, _lvlScale];
    }


    void Start()
    {
        EdgeDeterminant();
    }


    private void EdgeDeterminant()
    {
        for (int i = 0; i < _lvlScale; i++)
        {
            for (int j = 0; j < _lvlScale; j++)
            {
                if (i == 0 || i == _lvlScale - 1 || j == 0 || j == _lvlScale - 1)
                {
                    GameObject messer = Instantiate(edgeBoard, this.gameObject.transform, true);
                    messer.transform.position = new Vector3(i , 1, j * 1f);

                }
            }
        }
    }
}
