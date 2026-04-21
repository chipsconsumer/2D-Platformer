using System;
using TMPro;
using UnityEngine;

public class UiHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public playerhealth playerhealth; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerhealth.OnHealChanged += OnHealChanged;
        playerhealth.OnHealthInitialised += OnHealthInit;
          
    }

    private void OnHealthInit(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void OnHealChanged(float newhealth, float amountChanged)
    {
       // Debug.Log("On Health Changed Event");
       healthText.text = newhealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
