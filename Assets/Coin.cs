using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;
    private void
        OnTriggerEnter2D(Collider2D collision)
    {
        CoinCounter counter = collision.GetComponent<CoinCounter>();
        if (counter != null)
        {
            counter.AddCoin(scoreValue);
            Destroy(gameObject);
        }
    }
}