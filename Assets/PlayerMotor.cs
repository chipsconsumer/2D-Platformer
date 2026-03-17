using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    public float acceleration = 10;
    public float stoppingForce = 10;
    public float maxSpeedX = 10;
    public float stoppingPoint = 0.1f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //accelerate if pressing button
        if (direction.x != 0)
        {
            rb.AddForce(new Vector2(direction.x * acceleration, 0));
        }
        //if not accelerating start slowing down
        else if (rb.linearVelocityX != 0)
        {
            //if almost stopped, force stop
            if (rb.linearVelocityX < stoppingPoint && rb.linearVelocityX > -stoppingPoint)
            {
                rb.linearVelocity = new Vector2(0.0f, rb.linearVelocityY);
            }
            //add stopping force
            else
            {
                rb.AddForce(new Vector2(-rb.linearVelocityX * stoppingForce, 0));
            }
        }
        //Limit max speed
        if (rb.linearVelocityX >= maxSpeedX)
        {
            rb.linearVelocityX = maxSpeedX;
        }
        else if (rb.linearVelocityX <= -maxSpeedX)
        {
            rb.linearVelocityX = -maxSpeedX;
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
}
