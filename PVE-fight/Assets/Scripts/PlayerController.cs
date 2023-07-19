using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocitySpeed=3f;
    [SerializeField] private float jumpSpeed = 8f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {

            rb.velocity = new Vector2(-velocitySpeed, rb.velocity.y);
            animator.SetBool("Run", true);
            spriteRenderer.flipX = true;

        }
        else if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(velocitySpeed, rb.velocity.y);
            animator.SetBool("Run", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("w") && OnGround.onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (OnGround.onGround == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (OnGround.onGround == true)
        {
            animator.SetBool("Jump", false);
        }
    }

}
