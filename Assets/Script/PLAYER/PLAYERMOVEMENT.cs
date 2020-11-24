using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    Material mat;
    public Material matGun;

    Animator anim;
    Rigidbody2D rb;
    public float speed;
    public float SuperSpeed = 5f;
    public Joystick mj;
    public float jumpspeed;
    public CharacterController2D controller;
    bool jump = false;
    float horizontalmove;
    float x;
    bool crouch = false;
    [Range(1, 10)]
    public float jumpvelocity;

    public float spawnSpeed = 1f;
    float fade = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Dissolve();
        horizontalmove = x = mj.Horizontal * speed;
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        float verticalmove = mj.Vertical * jumpspeed;
        if (verticalmove >= 7f)
        {
            jump = true;
            //GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpvelocity;   
        }
        if (verticalmove > -1f)
        {
            crouch = false;
        }
        else if (verticalmove < -4.5f)
        {
            crouch = true;
        }
        if (verticalmove >= 0f)
        {
            crouch = false;
        }
        AnimationControl();

    }
    private void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void AnimationControl()
    {
        if (rb.velocity.x == 0 && !crouch)
        {
            anim.Play("Idle");
        }
        if (rb.velocity.x != 0 && !crouch)
        {
            anim.Play("Run");
        }        
        if (rb.velocity.x != 0 && crouch)
        {
            anim.Play("CrouchWalk");
        }
        if (crouch)
        {
            anim.Play("CrouchIdle");
        }
    }

    void Dissolve()
    {
        if (fade <= 1f)
        {
            fade += (spawnSpeed * Time.deltaTime);
            mat.SetFloat("_Fade", fade);
            matGun.SetFloat("_Fade", fade);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Lift"))
        {
            this.transform.parent = other.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lift"))
        {
            this.transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.CompareTag("FastRun"))
        {
            speed = speed + SuperSpeed ;
        }
    }
}
