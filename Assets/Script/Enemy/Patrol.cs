using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    Animator anim;
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        anim.Play("Run");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        Physics2D.IgnoreLayerCollision(12,12);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
