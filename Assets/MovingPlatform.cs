using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed = 2f;

    private Vector2 targetPos;
    private Rigidbody2D rb;
    private Vector2 platformVelocity;
    private Vector2 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = new Vector2(posB.position.x, posB.position.y);
        lastPosition = rb.position;
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;

        // RUCH PLATFORMY
        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        // RZECZYWISTA PREDKOŚĆ PLATFORMY
        platformVelocity = (newPos - lastPosition) / Time.fixedDeltaTime;
        lastPosition = newPos;

        // Jeśli platforma jest bardzo blisko celu zmien kierunek
        if (Vector2.Distance(currentPos, targetPos) < 0.05f)
        {
            if (targetPos == (Vector2)posB.position)
                targetPos = (Vector2)posA.position;
            else
                targetPos = (Vector2)posB.position;
        }
    }

    //POPRAWIONA! wersja gdzie nie występuje zmiana skali w player xd
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                
                if (collision.contacts[0].normal.y < -0.5f)
                {
                    
                    playerRb.position += platformVelocity * Time.fixedDeltaTime;
                }
            }
        }
    }
}