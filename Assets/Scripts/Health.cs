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

    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //Start at max health
        currentHealth = maxHealth;

        //Set the max health for the health bar
        healthBar.SetMaxHealth(maxHealth);

        //Get the player
        player = FindObjectOfType<PlayerController>();
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
            if (player.pawn.health.currentHealth <= 0)
            {
                //If the player has no more lives...
                if (GameManager.instance.lives <= 0)
                {
                    //Activate the game over UI
                    GameManager.instance.hudManager.gameOverUI.SetActive(true);
                }
                else
                {
                    //Respawn the player
                    player.Respawn();

                    //Subtract 1 life
                    GameManager.instance.lives--;

                    //Update the lives UI text
                    GameManager.instance.hudManager.SetLifeCountText();

                    //Reset the player health
                    player.pawn.health.currentHealth = player.pawn.health.maxHealth;

                    //Update the health bar on respawn
                    healthBar.SetHealth(currentHealth);
                }
            }
            else
            {
                GameManager.instance.killCount++;
                GameManager.instance.hudManager.SetKillCountText();
            }

            OnDie.Invoke();
        }
        else
        {
            //Don't go over max health
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }
}
