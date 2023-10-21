using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celso_PlanePosition : MonoBehaviour
{
    private static int _dificulty = Celso_Definitions._lvlScaleDeterminant;
    private int[,] _airplanePosition = new int[_dificulty,_dificulty];
    [SerializeField] private GameObject goodPlane;
    [SerializeField] private GameObject badPlane;
    private GameObject _badPlaneInstanced;
    private GameObject _goodPlaneInstanced;
    private bool _isMoving ;
    

    public static event Action OnAirplaneMoved;



    void Start()
    {
        _airplanePosition = Celso_Definitions._mapReferenceDeterminant;
        Celso_Definitions.Level1();
        PlaneInstatiate();
    }

     void Update()
    
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            _isMoving = true;
        }

    }

     void FixedUpdate()
    {
        if (_isMoving)
        {
            _goodPlaneInstanced.transform.position += new Vector3(  1,0,0);
            OnAirplaneMoved?.Invoke();
            _isMoving = false;
        }
    }


    private void PlaneInstatiate()
    {
        for (int i = 0; i < _dificulty; i++)
        {
            for (int j = 0; j < _dificulty; j++)
            {
                if (_airplanePosition[i, j] == 1)
                {
                    _goodPlaneInstanced = Instantiate(goodPlane, this.gameObject.transform);
                    _goodPlaneInstanced.transform.position = new Vector3(i, .3f, j );
                    _goodPlaneInstanced.transform.rotation =  Quaternion.Euler( 0,0, 0);
                }
                
                if (_airplanePosition[i, j] == 2)
                {
                     _badPlaneInstanced = Instantiate(badPlane, this.gameObject.transform);
                    _badPlaneInstanced.transform.position = new Vector3(i, .3f, j );
                    _badPlaneInstanced.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

    }
}