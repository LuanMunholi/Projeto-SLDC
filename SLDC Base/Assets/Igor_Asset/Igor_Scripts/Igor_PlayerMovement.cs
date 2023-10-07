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
                MoveToCell(new Vector3(0,0,1));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveToCell(new Vector3(0, 0, -1));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveToCell(new Vector3(-1, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveToCell(new Vector3(1, 0, 0));
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

    // Função para mover o jogador para uma célula adjacente na grade
    private void MoveToCell(Vector3 direction)
    {
        Vector3 currentPosition = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        Vector3 targetCell = currentPosition + direction;

        // Certifique-se de que o alvo esteja dentro dos limites da grid
        // Substitua os valores 10 e -10 pelos limites da sua grid, se necessário
        if (targetCell.x >= -10 && targetCell.x <= 10 && targetCell.y >= -10 && targetCell.y <= 10 && targetCell.z >= -10 && targetCell.z <= 10)
        {
            // Converter Vector2 para Vector3, definindo a componente Z como a mesma do jogador
            targetPosition = new Vector3(targetCell.x, targetCell.y, targetCell.z);
            isMoving = true;
        }
    }

}
