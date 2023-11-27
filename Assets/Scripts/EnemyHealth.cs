using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; //Max health of enemy
    public int currentHealth; //Current health of enemy

    public interface IDamageable
    {
        void TakeDamage(int damageAmount);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Set current health to max at start
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; //Reduce health by damage amount

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy has died");
        Destroy(gameObject); //Destroy the enemy object when it dies
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
