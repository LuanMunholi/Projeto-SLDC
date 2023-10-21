using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Celso_LevelInstantiator : MonoBehaviour
{
    [SerializeField] public GameObject edgeBoard;
    [SerializeField] public GameObject edgeSquare;
    [SerializeField] public GameObject middleMap;
    
    [SerializeField] private static int _lvlScale = Celso_Definitions._lvlScaleDeterminant;
    [SerializeField] private int[,] _mapReference = Celso_Definitions._mapReferenceDeterminant;

    
    void Start()
    {
        EdgeDeterminant();
    }

    private void MapPlacer( GameObject mapPiece, int x, int z, int rot)
    {
        GameObject messer = Instantiate(mapPiece, this.gameObject.transform);
        messer.transform.position = new Vector3(x-_lvlScale/2, 0, z-_lvlScale/2 );
        messer.transform.rotation =  Quaternion.Euler( 0,rot, 0);
    }

    private void EdgeDeterminant()
    {
        for (int i = 0; i < _lvlScale  ; i++)
        {
            for (int j = 0; j < _lvlScale; j++)
            {
                if   (i == 0 && j != i && j != _lvlScale - 1)
                {
                    MapPlacer(edgeBoard, i, j, 90);
                }

                else if  (j == 0 && j != i && i != _lvlScale - 1)
                {
                    MapPlacer(edgeBoard, i, j, 0);
                }

                else if (i == _lvlScale - 1 && j != i && j != 0)
                {
                    MapPlacer(edgeBoard, i, j, 270);
                }

                else if (j == _lvlScale - 1 && j != i && i != 0)
                {
                    MapPlacer(edgeBoard, i, j, 180);
                }

                else if (j == 0 && i == 0)
                {
                    MapPlacer(edgeSquare, i, j, 0);
                }

                else if (j == 0 && i == _lvlScale - 1){
                    MapPlacer(edgeSquare, i, j, 270);
                }

                else if (j == _lvlScale - 1 && i == 0)
                {
                    MapPlacer(edgeSquare, i, j, 90);
                }
                
                else if (j == _lvlScale - 1 && i ==_lvlScale - 1)
                {
                    MapPlacer(edgeSquare, i, j, 180);
                }

                else if (i>=1 && i <=_lvlScale - 2 && j>=1 && j <=_lvlScale - 2 )
                {
                    MapPlacer(middleMap, i, j, 0);
                }
            }
        }
    }
}
