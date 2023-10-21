using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Celso_Definitions;

public class Celso_MesserController : MonoBehaviour
{
    delegate void MovementLevel();
    private int _movementCounter = 0;
    private List<MovementLevel> _changePosition = new List<MovementLevel>();

    private void Start()
    {
        CreateLevel();
    }

    void OnEnable()
    {
        _movementCounter++;
        Celso_PlanePosition.OnAirplaneMoved += MoveThisObject ;
        Debug.Log(GetMoveCount().ToString());
    }
    
    void OnDisable()
    {
        Celso_PlanePosition.OnAirplaneMoved -= MoveThisObject;
    }

    private void MoveThisObject()
    {
        _changePosition[_movementCounter++]();
    }


    void CreateLevel()
    {
        if (_lvlScaleDeterminant == 5)
        {
            _changePosition.Add(MoveX);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
        }
    }

    void  MoveZ()
    {
        transform.position +=  Vector3.back;
    }
    void MoveX()
    {
        transform.position += Vector3.up;
    }
    
    void MoveY()
    {
        transform.position +=Vector3.right;
    }
    
    public int GetMoveCount()
    {
        return _movementCounter;
    }
    
}
