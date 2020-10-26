using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBasic : MonoBehaviour
{
    public float speed = 10f;   //speed on x axis
    public float jumpPower = 15f;   //jumping force
    public float extraJumps = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform feet;
    
    int jumpCount = 0;
    bool isGrounded;
    float mx;   //serves for horizantal movement
    float jumpCoolDown;     //compensates for different machiens

    public float dashDistance = 15f;        //fixed dash distance but it can be changed in unity
    bool isDashing;     //checks condition if dashing

    float doubleTapTime;        // checks for double tap on a key A and D for our movment
    KeyCode lastKeyCode;        //checks last keycode of teh SAME KEY

    private void Update()
    {
        mx = Input.GetAxis("Horizontal");       // has game pick direction we're facing

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        // dash left
        if (Input.GetKeyDown(KeyCode.A)) {
            if(doubleTapTime > Time.time && lastKeyCode == KeyCode.A) {
                //actual dash
                StartCoroutine(Dash(-1f));
            } else {
                doubleTapTime = Time.time + 0.25f;      // 1/4 to tap a second time
            }

            lastKeyCode = KeyCode.A;
        }

        // dash right
        if (Input.GetKeyDown(KeyCode.D)) {
            if(doubleTapTime > Time.time && lastKeyCode == KeyCode.D) {
                //actual dash
                StartCoroutine(Dash(1f));
            } else {
                doubleTapTime = Time.time + 0.25f;      // 1/4 to tap a second time
            }

            lastKeyCode = KeyCode.D;
        }

        CheckGrounded();
    }

    private void FixedUpdate()
    {
        if(!isDashing)
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded || jumpCount < extraJumps) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer)) {
            isGrounded = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;        // allows a small window to correct jump
        } else if (Time.time < jumpCoolDown) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

    IEnumerator Dash (float direction)
    {
        isDashing = true;       // set dashing state
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);     // if -1 go other way otherwise multiiply dir by 1
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;        // needed to dash in a straight line
        yield return new WaitForSeconds(0.2f);      // a brief wait or how long to dash for

        //end of dash
        isDashing = false;
        rb.gravityScale = gravity;      //return gravity to normal
    }
}
