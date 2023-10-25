using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luan_PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float rayLength = 1f;
    [SerializeField] float rayOffsetX = 0.49f;
    [SerializeField] float rayOffsetY = -0.5f;
    [SerializeField] float rayOffsetZ = 0.49f;

    [SerializeField] LayerMask obstacle = 0;
    [SerializeField] LayerMask boxMask = 0;
    [SerializeField] LayerMask groundLayer = 0;

    [SerializeField] Transform groundCheck;

    [SerializeField] AudioSource stepOne, stepTwo;

    Vector3 xOffset;
    Vector3 yOffset;
    Vector3 zOffset;
    Vector3 zAxisOriginA;
    Vector3 zAxisOriginB;
    Vector3 xAxisOriginA;
    Vector3 xAxisOriginB;

    Vector3 targetPosition;
    Vector3 startPosition;

    public bool moving, isGrounded, stepSound = false;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        Debug.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * 0.2f, isGrounded ? Color.green : Color.red);

        yOffset = transform.position + Vector3.up * rayOffsetY;
        zOffset = Vector3.forward * rayOffsetZ;
        xOffset = Vector3.right * rayOffsetX;

        zAxisOriginA = yOffset + xOffset;
        zAxisOriginB = yOffset - xOffset;

        xAxisOriginA = yOffset + zOffset;
        xAxisOriginB = yOffset - zOffset;

        // Draw Debug Rays
        
        Debug.DrawLine(
                zAxisOriginA,
                zAxisOriginA + Vector3.forward * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                zAxisOriginB,
                zAxisOriginB + Vector3.forward * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                zAxisOriginA,
                zAxisOriginA + Vector3.back * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                zAxisOriginB,
                zAxisOriginB + Vector3.back * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                xAxisOriginA,
                xAxisOriginA + Vector3.left * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                xAxisOriginB,
                xAxisOriginB + Vector3.left * rayLength,
                Color.red,
                Time.deltaTime);

        Debug.DrawLine(
                xAxisOriginA,
                xAxisOriginA + Vector3.right * rayLength,
                Color.red,
                Time.deltaTime);
        Debug.DrawLine(
                xAxisOriginB,
                xAxisOriginB + Vector3.right * rayLength,
                Color.red,
                Time.deltaTime);

        if (moving) {
            if (Vector3.Distance(startPosition, transform.position) > 1f){
                transform.position = targetPosition;
                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.W)) {

            if (CanMove(Vector3.forward) && TryPushBox(Vector3.forward) && isGrounded) {

                transform.localEulerAngles = new Vector3(0, 0, 0);

                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;

                moving = true;

                if (stepSound){
                    stepOne.Play();
                    stepSound = false;
                } else {
                    stepTwo.Play();
                    stepSound = true;
                }

            }

        } else if (Input.GetKeyDown(KeyCode.S)) {

            if (CanMove(Vector3.back) && TryPushBox(Vector3.back) && isGrounded) {

                transform.localEulerAngles = new Vector3(0, 180, 0);

                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;

                moving = true;

                if (stepSound){
                    stepOne.Play();
                    stepSound = false;
                } else {
                    stepTwo.Play();
                    stepSound = true;
                }
                
            }

        } else if (Input.GetKeyDown(KeyCode.A)) {

            if (CanMove(Vector3.left) && TryPushBox(Vector3.left) && isGrounded) {

                transform.localEulerAngles = new Vector3(0, -90, 0);

                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;

                moving = true;

                if (stepSound){
                    stepOne.Play();
                    stepSound = false;
                } else {
                    stepTwo.Play();
                    stepSound = true;
                }

            }

        } else if (Input.GetKeyDown(KeyCode.D)) {

            if (CanMove(Vector3.right) && TryPushBox(Vector3.right) && isGrounded) {

                transform.localEulerAngles = new Vector3(0, 90, 0);

                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;

                moving = true;

                if (stepSound){
                    stepOne.Play();
                    stepSound = false;
                } else {
                    stepTwo.Play();
                    stepSound = true;
                }

            }

        }

    }

    bool CanMove(Vector3 direction) {
        
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

    bool TryPushBox(Vector3 direction){

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, rayLength, boxMask)){

            BoxMovement box = hit.collider.GetComponent<BoxMovement>();

            if(box.CanMove(direction)){
                box.MoveBox(direction);
                return true;
            }

            return false;

        } return true;        
        
    }

}