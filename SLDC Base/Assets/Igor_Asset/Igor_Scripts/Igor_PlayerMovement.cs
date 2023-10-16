using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igor_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    private Vector3 targetPosition; // A posição de destino do jogador
    private bool isMoving = false; // Indica se o jogador está se movendo

    private void Update()
    {
        // Verifique se o jogador não está se movendo e se há uma entrada de movimento
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMove(Vector3.forward);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMove(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMove(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMove(Vector3.right);
            }
        }

        // Movimentação suave em direção à posição de destino
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    // Função para tentar mover o jogador para uma célula adjacente na grade
    private void TryMove(Vector3 direction)
    {
        Vector3 currentPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        Vector3 targetCell = currentPosition + direction;

        // Certifique-se de que o alvo esteja dentro dos limites da grid
        if (IsCellWithinBounds(targetCell) && !IsCellBlockedByObstacle(targetCell))
        {
            // Se a célula não estiver bloqueada por um obstáculo, mova o jogador para ela
            targetPosition = targetCell;
            isMoving = true;
        }
    }

    // Função para verificar se uma célula está dentro dos limites da grid
    private bool IsCellWithinBounds(Vector3 cell)
    {
        return cell.x >= -10 && cell.x <= 10 && cell.y >= -10 && cell.y <= 10 && cell.z >= -10 && cell.z <= 10;
    }

    // Função para verificar se uma célula está bloqueada por um objeto com a tag "obstaculo"
    private bool IsCellBlockedByObstacle(Vector3 cell)
    {
        Collider[] colliders = Physics.OverlapBox(cell, Vector3.one * 0.4f); // Use um tamanho apropriado para o seu jogo

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("obstaculo"))
            {
                return true; // A célula está bloqueada por um obstáculo
            }
        }

        return false; // A célula não está bloqueada por obstáculos
    }
}
