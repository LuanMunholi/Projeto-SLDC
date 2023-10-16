using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igor_BoxMove : MonoBehaviour
{
    private Vector3 initialPosition; // Posi��o inicial da caixa
    private bool isBeingPushed = false; // Indica se a caixa est� sendo empurrada

    private void Start()
    {
        initialPosition = transform.position; // Armazena a posi��o inicial da caixa
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBeingPushed = true; // A caixa est� sendo empurrada pelo jogador
        }
    }

    private void Update()
    {
        if (isBeingPushed)
        {
            // Obt�m a dire��o do movimento do jogador
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (moveDirection != Vector3.zero)
            {
                // Calcula a nova posi��o da caixa com base na dire��o do movimento do jogador
                Vector3 newPosition = transform.position + moveDirection;

                // Arredonda a nova posi��o para a grade (uma unidade por vez)
                newPosition = new Vector3(Mathf.Round(newPosition.x), Mathf.Round(newPosition.y), Mathf.Round(newPosition.z));

                // Move a caixa para a nova posi��o
                transform.position = newPosition;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBeingPushed = false; // O jogador parou de empurrar a caixa
        }
    }
}
