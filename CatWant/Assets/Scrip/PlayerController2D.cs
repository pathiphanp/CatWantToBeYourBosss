using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Transform Cat;
    public LayerMask layerMask;

    float JumpTime = 2f;
    float TimeJump = 0;
    public float JumpForce;
    public float CircleRadius;

    public float speed;
    float MoveX;

    Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        jump();
        GroundCheck();
    }

    void Movement()
    {
        MoveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(MoveX * speed, rb.velocity.y);
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TimeJump < JumpTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            TimeJump += 1;
        }
    }

    void GroundCheck()
    {
        if (Physics2D.OverlapCircle(Cat.transform.position, CircleRadius, layerMask) && rb.velocity.y <= 0)
        {
            TimeJump = 0;
        }
    }
}
