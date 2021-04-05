using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;

    GameManager gameManager;

    void SetMovementVector()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; //normalizes movement to avoid making diagonal movement faster
    }
    void SetMovementToZero()
    {
        movement.x = 0;
        movement.y = 0;
        movement.Normalize();
    }
    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gameManager.currentGameState == GameState.Overworld)
            SetMovementVector();
        else
            SetMovementToZero();
    }
    private void FixedUpdate()
    {
        if (gameManager.currentGameState == GameState.Overworld)
            Move();
    }
}
