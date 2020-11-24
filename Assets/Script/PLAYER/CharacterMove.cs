using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public VariableJoystick joystick;
    public JoyButton joybutton;
    private Rigidbody2D rb;
    private Animator anim;

    Vector2 movement;

    public float moveSpeed = 5;
    private Vector3 localScale;
    public bool isGrounded;
    public Transform groundChecker;
    public float checkRadius;
    public LayerMask ground;
    public float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;

        AnimationControl();
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, checkRadius, ground);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        //rb.velocity = new Vector2(dirX, 0);
        if (isGrounded == true && joybutton.Pressed)
        {
            rb.velocity = Vector2.up * jumpForce * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    private void AnimationControl()
    {
        if (rb.velocity.y == 0 && rb.velocity.x == 0)
        {
            anim.Play("Idle");
        }
        if (rb.velocity.y != 0 || rb.velocity.x != 0)
        {
            anim.Play("Run");
        }
    }

}
