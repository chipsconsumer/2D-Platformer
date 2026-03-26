using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpforce = 5;
    public float maxspeed = 10;
    public float stoppingForce = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
        HandleMaxSpeed();
        PlayerStopping();

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
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
