using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpforce = 7;
    public float maxspeed = 10;
    public float stoppingForce = 10;
    public float dashForce = 20;

    private bool canDash = true;
    private bool isDashing = false;
    private int _jumpCount = 0;
    public int maxJumpCount = 2;
       
    private void Start()
    {
rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isDashing)
        {
            PlayerMovement();
            HandleMaxSpeed();
            PlayerStopping();
        }
        

    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)

        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void HandleMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= maxspeed)
        {
            rigidbody2D.linearVelocityX = maxspeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxspeed)
        {
            rigidbody2D.linearVelocityX = -maxspeed;
        }
    }

    private void PlayerMovement()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }


    private void OnJump()
    {
        if (canJump)
        {
        
           
            rigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            _jumpCount++;
            if (_jumpCount >= maxJumpCount)
            {
                canJump = false;
            }
            
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        canJump = true;
        _jumpCount = 0;
    }

    // DASHiNG
    private void OnDash()
    {
        if (canDash && direction.x != 0)
        {
            StartCoroutine(DashRoutine());
        }
    }
    private System.Collections.IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
        rigidbody2D.linearVelocity = new Vector2(direction.x * dashForce, 0);
        yield return new WaitForSeconds(0.2f);
        rigidbody2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(1f);
        canDash = true;
    }
}



 
