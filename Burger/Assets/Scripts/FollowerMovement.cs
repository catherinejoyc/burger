using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMovement : MonoBehaviour
{
    public Transform destination;
    public float moveSpeed;
    public float maxDistance;
    Rigidbody2D rb;
    Vector2 movement;

    void SetMovementVector()
    {
        Vector2 direction = destination.position - transform.position;
        direction.Normalize();
        movement = direction;
    }
    void Move(Vector2 direction)
    {
        if (Vector2.Distance(destination.position, transform.position) > maxDistance)
        {
            //rb.MovePosition((Vector2)transform.position + movement * moveSpeed * Time.fixedDeltaTime);
            rb.AddForce((destination.position - transform.position) * moveSpeed * Vector2.Distance(destination.position, transform.position) * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetMovementVector();
    }
    private void FixedUpdate()
    {
        Move(movement);
    }
}
