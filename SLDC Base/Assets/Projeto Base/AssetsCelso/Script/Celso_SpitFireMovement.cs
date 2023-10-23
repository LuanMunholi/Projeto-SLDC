using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celso_SpitFireMovement : MonoBehaviour
{
    private bool _isMoving ;
    private Rigidbody _rb;
    public static event Action OnAirplaneMoved;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
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
            this._rb.AddForce(new Vector3(5,0,0),ForceMode.Impulse) ;
            OnAirplaneMoved?.Invoke();
            _isMoving = false;
        }
    }
}
