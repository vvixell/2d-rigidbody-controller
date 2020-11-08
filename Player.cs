using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpHeight;

    [Header("Ground Checking")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize;

    public LayerMask mask;

    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //movement
        Move();
    }
    
    void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        isGrounded = Physics2D.BoxCast(groundCheckPos.position, groundCheckSize, 0, Vector2.zero, 0, mask);

        Vector2 move = new Vector2(xMove, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded)
            move = new Vector2(rb.velocity.x, jumpHeight);

        rb.velocity = move;
    }
}
