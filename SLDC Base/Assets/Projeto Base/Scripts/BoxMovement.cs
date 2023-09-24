using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rayLength = 1.4f;

    Vector3 moveDirection;
    Vector3 targetPosition;
    Vector3 startPosition;

    bool moving, beingPushed;

    void Update(){

        if (moving) {
            if (Vector3.Distance(startPosition, transform.position) > 1f){
                transform.position = targetPosition;
                beingPushed = false;
                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        if (beingPushed){
            if (Vector3.Dot(moveDirection.normalized, Vector3.forward) > 0f) {
                if (CanMove(Vector3.forward)) {
                    targetPosition = transform.position + Vector3.forward;
                    startPosition = transform.position;
                    moving = true;
                }
            } else if (Vector3.Dot(moveDirection.normalized, Vector3.back) > 0f) {
                if (CanMove(Vector3.back)) {
                    targetPosition = transform.position + Vector3.back;
                    startPosition = transform.position;
                    moving = true;
                }
            } else if (Vector3.Dot(moveDirection.normalized, Vector3.left) > 0f) {
                if (CanMove(Vector3.left)) {
                    targetPosition = transform.position + Vector3.left;
                    startPosition = transform.position;
                    moving = true;
                }
            } else if (Vector3.Dot(moveDirection.normalized, Vector3.right) > 0f) {
                if (CanMove(Vector3.right)) {
                    targetPosition = transform.position + Vector3.right;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }

    }

    public void MoveBox(Vector3 direction){
        moveDirection = direction;
        beingPushed = true;
        return;
    }

    public bool CanMove(Vector3 direction) {
        if (Physics.Raycast(transform.position, direction, rayLength)) 
                return false;
        return true;
    }

}
