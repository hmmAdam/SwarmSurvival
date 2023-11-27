using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; //Max health of player
    public int currentHealth; //Current health of player

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Set current health to max health at the start
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; //Reduce health by damage amount

        //Check if health drops to zero or below
        if (currentHealth <= 0)
        {
            Die(); //Player dies if health hits zero or less
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healthAmount, maxHealth); //Increase health, capped at max health
    }

    //Death method
    void Die()
    {
        //Perform actions when the player dies, e.g, game over screen, respawn logic etc.
        Debug.Log("Player has died");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
