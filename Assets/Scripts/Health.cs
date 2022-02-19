using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Values")]
    public float maxHealth;
    public float currentHealth;

    [Header("Events")]
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;

    [Header("Health Bar")]
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Start at max health
        currentHealth = maxHealth;

        //Set the max health for the health bar
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float amountOfDamage)
    {
        //Call the OnTakeDamage event
        OnTakeDamage.Invoke();

        //Subtract health
        currentHealth -= amountOfDamage;

        //Update the health bar
        healthBar.SetHealth(currentHealth);

        //If our health is < 0 we die
        if (currentHealth <= 0)
        {
            OnDie.Invoke();
        }
        else
        {
            //Don't go over max health
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }
}
