using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damageAmount = 10; //Amount of damage player deals

    void OnTriggerEnter(Collider other)
    {
        //Check if object collided with is damageable
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Deal damage to collided object
            damageable.TakeDamage(damageAmount);
        }
    }
}
