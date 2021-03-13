using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;
    bool isMoving = true;

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

    void StartMoving()
    {
        isMoving = true;
    }
    void StopMoving()
    {
        isMoving = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.OverworldGSEvent.AddListener(StartMoving);
        GameManager.Instance.DialogGSEvent.AddListener(StopMoving);
    }
    void Update()
    {
        if (isMoving)
            SetMovementVector();
        else
            SetMovementToZero();
    }
    private void FixedUpdate()
    {
        Move();
    }
}
