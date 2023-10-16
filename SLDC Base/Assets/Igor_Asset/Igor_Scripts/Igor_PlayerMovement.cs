using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igor_PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    private Vector3 targetPosition; // A posi��o de destino do jogador
    private bool isMoving = false; // Indica se o jogador est� se movendo

    private void Update()
    {
        // Verifique se o jogador n�o est� se movendo e se h� uma entrada de movimento
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

        // Movimenta��o suave em dire��o � posi��o de destino
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    // Fun��o para tentar mover o jogador para uma c�lula adjacente na grade
    private void TryMove(Vector3 direction)
    {
        Vector3 currentPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        Vector3 targetCell = currentPosition + direction;

        // Certifique-se de que o alvo esteja dentro dos limites da grid
        if (IsCellWithinBounds(targetCell) && !IsCellBlockedByObstacle(targetCell))
        {
            // Se a c�lula n�o estiver bloqueada por um obst�culo, mova o jogador para ela
            targetPosition = targetCell;
            isMoving = true;
        }
    }

    // Fun��o para verificar se uma c�lula est� dentro dos limites da grid
    private bool IsCellWithinBounds(Vector3 cell)
    {
        return cell.x >= -10 && cell.x <= 10 && cell.y >= -10 && cell.y <= 10 && cell.z >= -10 && cell.z <= 10;
    }

    // Fun��o para verificar se uma c�lula est� bloqueada por um objeto com a tag "obstaculo"
    private bool IsCellBlockedByObstacle(Vector3 cell)
    {
        Collider[] colliders = Physics.OverlapBox(cell, Vector3.one * 0.4f); // Use um tamanho apropriado para o seu jogo

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("obstaculo"))
            {
                return true; // A c�lula est� bloqueada por um obst�culo
            }
        }

        return false; // A c�lula n�o est� bloqueada por obst�culos
    }
}
