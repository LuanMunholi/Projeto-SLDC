using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igor_BoxMove : MonoBehaviour
{
    private Vector3 initialPosition; // Posição inicial da caixa
    private bool isBeingPushed = false; // Indica se a caixa está sendo empurrada

    private void Start()
    {
        initialPosition = transform.position; // Armazena a posição inicial da caixa
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBeingPushed = true; // A caixa está sendo empurrada pelo jogador
        }
    }

    private void Update()
    {
        if (isBeingPushed)
        {
            // Obtém a direção do movimento do jogador
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (moveDirection != Vector3.zero)
            {
                // Calcula a nova posição da caixa com base na direção do movimento do jogador
                Vector3 newPosition = transform.position + moveDirection;

                // Arredonda a nova posição para a grade (uma unidade por vez)
                newPosition = new Vector3(Mathf.Round(newPosition.x), Mathf.Round(newPosition.y), Mathf.Round(newPosition.z));

                // Move a caixa para a nova posição
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
