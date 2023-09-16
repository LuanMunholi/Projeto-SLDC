using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rayLength = 1.4f;
    [SerializeField] float rayOffsetX = 0.5f;
    [SerializeField] float rayOffsetY = 0.5f;
    [SerializeField] float rayOffsetZ = 0.5f;
    [SerializeField] LayerMask obstacle = 0;

    Vector3 xOffset;
    Vector3 yOffset;
    Vector3 zOffset;
    Vector3 zAxisOriginA;
    Vector3 zAxisOriginB;
    Vector3 xAxisOriginA;
    Vector3 xAxisOriginB;

    Vector3 moveDirection;
    Vector3 targetPosition;
    Vector3 startPosition;

    bool moving, beingPushed;

    void Update(){

        yOffset = transform.position + Vector3.up * rayOffsetY;
        zOffset = Vector3.forward * rayOffsetZ;
        xOffset = Vector3.right * rayOffsetX;

        zAxisOriginA = yOffset + xOffset;
        zAxisOriginB = yOffset - xOffset;

        xAxisOriginA = yOffset + zOffset;
        xAxisOriginB = yOffset - zOffset;

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

    private bool CanMove(Vector3 direction) {
        if (direction.z != 0) {
            if (Physics.Raycast(zAxisOriginA, direction, rayLength, obstacle)) return false;
            if (Physics.Raycast(zAxisOriginB, direction, rayLength, obstacle)) return false;
        }
        else if (direction.x != 0) {
            if (Physics.Raycast(xAxisOriginA, direction, rayLength, obstacle)) return false;
            if (Physics.Raycast(xAxisOriginB, direction, rayLength, obstacle)) return false;
        }
        return true;
    }

}
