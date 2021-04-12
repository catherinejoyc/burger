using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;

    public Animator animator;
    //public Animation anim;

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
        //anim = gameObject.GetComponent<Animation>();
        gameManager = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gameManager.currentGameState == GameState.Overworld)
            SetMovementVector();
        else
            SetMovementToZero();

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        //if (movement.x > 0)
        //{
        //    anim.Play("Viktoria_WalkRight");
        //    Debug.Log("WalkRight");
        //}
        //if (movement.x < 0)
        //{
        //    anim.Play("Viktoria_WalkLeft");
        //    Debug.Log("WalkLeft");
        //}
        //if (movement.x == 0)
        //{
        //    anim.Play("Viktoria_Idle");
        //    Debug.Log("Idle");
        //}
    }
    private void FixedUpdate()
    {
        if (gameManager.currentGameState == GameState.Overworld)
            Move();
    }
}
