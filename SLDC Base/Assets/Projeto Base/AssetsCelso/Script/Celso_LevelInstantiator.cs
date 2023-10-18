using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Celso_LevelInstantiator : MonoBehaviour
{
    [SerializeField] public GameObject edgeBoard;
    [SerializeField] public GameObject edgeSquare;
    [SerializeField] public GameObject middleMap;
    
    [SerializeField] private static int _lvlScale = 6;
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

    private void MapPlacer( GameObject mapPiece, int x, int z, int rot)
    {
        GameObject messer = Instantiate(mapPiece, this.gameObject.transform, true);
        messer.transform.position = new Vector3(x, 0, z );
        messer.transform.rotation =  Quaternion.Euler( 0,rot, 0);
    }

    private void EdgeDeterminant()
    {
        for (int i = 0; i < _lvlScale  ; i++)
        {
            for (int j = 0; j < _lvlScale; j++)
            {
                if (i == 0 && j != i && j != _lvlScale - 1)
                {
                    MapPlacer(edgeBoard, i, j, 90);
                }

                if (j == 0 && j != i && i != _lvlScale - 1)
                {
                    MapPlacer(edgeBoard, i, j, 0);
                }

                if (i == _lvlScale - 1 && j != i && j != 0)
                {
                    MapPlacer(edgeBoard, i, j, 270);
                }

                if (j == _lvlScale - 1 && j != i && i != 0)
                {
                    MapPlacer(edgeBoard, i, j, 180);
                }

                if (j == 0 && i == 0)
                {
                    MapPlacer(edgeSquare, i, j, 0);
                }

                if (j == 0 && i == _lvlScale - 1){
                    MapPlacer(edgeSquare, i, j, 270);
                }

                if (j == _lvlScale - 1 && i == 0)
                {
                    MapPlacer(edgeSquare, i, j, 90);
                }
                
                if (j == _lvlScale - 1 && i ==_lvlScale - 1)
                {
                    MapPlacer(edgeSquare, i, j, 180);
                }

                if (i>=1 && i <=_lvlScale - 2 && j>=1 && j <=_lvlScale - 2 )
                {
                    MapPlacer(middleMap, i, j, 0);
                }
            }
        }
    }
}
