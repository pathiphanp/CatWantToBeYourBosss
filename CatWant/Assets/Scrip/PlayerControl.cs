using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public Transform Player;
    public LayerMask layerMask;
    public Vector3 Vec;
    public Animator animator;

    public float rotationSpeed;
    public float speed;
    public float JumpHeight;
    public float GravityValue;
    public float SphereRadius;
    public float JumpLimit = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        isAnimate();
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            transform.right = move;
        }

        direction = Player.position;
        direction.y = direction.y - 1f;

        Vec.y += GravityValue * Time.deltaTime;
        controller.Move(Vec * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && JumpLimit > 1)
        {
            Vec.y = Mathf.Sqrt(JumpHeight * -3f * GravityValue);
            JumpLimit -= 1;
            //Debug.Log("Jump");
        }

        //CheckGround
        if (Physics.CheckSphere(direction, SphereRadius, layerMask))
        {
            JumpLimit = 2;
            //Debug.Log("Yo");
        }
    }

    void isAnimate()
    {
        if (Input.GetKeyDown("a"))
        {
            animator.SetBool("IsWalk", true);
        }
        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("IsWalk", false);
        }

        if (Input.GetKeyDown("d"))
        {
            animator.SetBool("IsWalk", true);
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("IsWalk", false);
        }
    }
}
