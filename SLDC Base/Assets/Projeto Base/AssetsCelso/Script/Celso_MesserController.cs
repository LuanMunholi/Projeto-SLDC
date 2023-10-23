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
    private Rigidbody _rigidbodyMesser;
    private bool _isMoving = false;

    private Vector3 _oldPosition = Vector3.zero;
    private Vector3 _movementMagnitude = Vector3.zero;

    private void Awake()
    {
        _rigidbodyMesser = GetComponent<Rigidbody>();
        CreateLevel();
    }
    

    void OnEnable()
    {
        Celso_SpitFireMovement.OnAirplaneMoved += MoveThisObject ;
        Debug.Log(GetMoveCount().ToString());
    }
    
    void OnDisable()
    {
        Celso_SpitFireMovement.OnAirplaneMoved -= MoveThisObject;
        _rigidbodyMesser.AddForce(new Vector3(0,0,0),ForceMode.VelocityChange);
    }

    private void MoveThisObject()
    {       
        _isMoving = true;
        _movementCounter++;
    }

    private void FixedUpdate()
    {
        if (_isMoving == false)
        {
            _oldPosition = _rigidbodyMesser.position;
        }
        
        if (_isMoving == true)
        {
            _movementMagnitude = _rigidbodyMesser.position - _oldPosition; 
            _changePosition[_movementCounter]();
        } 
        if (_movementMagnitude.magnitude >= 1.0f)
        {
            _isMoving = false;
            _rigidbodyMesser.velocity = Vector3.zero;
        }
        
    }

    void CreateLevel()
    {
        if (_lvlScaleDeterminant == 5)
        {
            _changePosition.Add(MoveX);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveZ);
            _changePosition.Add(MoveX);
            _changePosition.Add(MoveZ);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveX);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveZ);
            _changePosition.Add(MoveX);
            _changePosition.Add(MoveZ);
            _changePosition.Add(MoveY);
            _changePosition.Add(MoveY);
        }
    }

    void  MoveZ()
    {
        _rigidbodyMesser.AddForce(new Vector3(0,0,1),ForceMode.Impulse);
    }
    void MoveX()
    {
        _rigidbodyMesser.AddForce(new Vector3(1,0,0),ForceMode.Impulse);
    }
    
    void MoveY()
    {
        _rigidbodyMesser.AddForce(new Vector3(0,1,0),ForceMode.Impulse);
    }
    
    public int GetMoveCount()
    {
        return _movementCounter;
    }
}
