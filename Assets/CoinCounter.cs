using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    private int currentCoins = 0;
    public TextMeshProUGUI coinText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        currentCoins += amount;
        UpdateUI();
    }
    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Monety: " + currentCoins.ToString();
        }
    }
}