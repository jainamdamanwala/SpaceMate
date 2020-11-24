using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterButtonController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed;
    public float jumpForce;
    public Joystick joystick;
    private float dirX;

    Material mat;
    public Material matGun;
    public float spawnSpeed = 1f;
    float fade = 0f;
    /*    private bool facingRight = true;
        private Vector3 localScale;*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //localScale = transform.localScale;

        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Dissolve();
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if(Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
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
    /*    private void LateUpdate()
        {
            if (joystick.Horizontal > 0f && !facingRight)
            {
                Flip();
            }
            if (joystick.Horizontal < 0f && facingRight)
            {
                Flip();
            }
        }
        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }*/
}
