using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityStandardAssets.CrossPlatformInput;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private UnityEngine.Vector3 localScale;

    private int aux = 0;
    private bool attacking = false;

    // public float speed;
    // public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("GoBack"))
        {
            SceneManager.LoadScene("Interfaz");
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(UnityEngine.Vector2.up * 800f);

        if (CrossPlatformInputManager.GetButtonDown("Attack") && rb.velocity.y == 0
            && !anim.GetBool("isWalking") && !anim.GetBool("isJumping")
            && !anim.GetBool("isFalling") && !anim.GetBool("isBending"))
        {
            anim.SetBool("isAttacking", true);
            attacking = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("Bend") && rb.velocity.y == 0
            && !anim.GetBool("isWalking") && !anim.GetBool("isJumping")
            && !anim.GetBool("isFalling") && !anim.GetBool("isAttacking"))
        {
            anim.SetBool("isBending", true);
        }
        else
        {
            anim.SetBool("isBending", false);
        }

            if (Math.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        
    }

    private void FixedUpdate()
    {
        rb.velocity = new UnityEngine.Vector2(dirX - 4f, rb.velocity.y);

        if (attacking)
        {
            aux++;
            if (aux > 50)
            {
                anim.SetBool("isAttacking", false);
                attacking = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // float moveBy = x * speed;
        // rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
