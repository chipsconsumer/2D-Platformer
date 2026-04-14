using System;
using System.Collections;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    private bool canReceiveDamage = true;
    public float invincibilityTimer = 2;



    public delegate void HealthChangeHandler(float newhealth, float amountChanged);
    public event HealthChangeHandler OnHealChanged;

    public delegate void HealthInitHandler (float newHealth);
    public event HealthInitHandler OnHealthInitialised;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddDamage(float damage)
    {
        if (canReceiveDamage)
        {
            health -= damage;
            OnHealChanged?.Invoke(health, -damage);
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
            
        }
        Debug.Log(health);
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canReceiveDamage = true;
        Debug.Log("reset");
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnHealChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);
    }
      

    
      
        
}