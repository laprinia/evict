using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;

    public HealthBar healthBar;

    
    void Start()
    {
        curHealth = maxHealth;
    }

   

    public void DamagePlayer( int damage )
    {
        if(curHealth >0){
            curHealth -= damage;

            healthBar.SetHealth(curHealth);
        }
        else
        {
            //todo end game
        }
    }

    public void HealPlayer(int heal)
    {
        curHealth += heal;
        healthBar.SetHealth(curHealth);
    }

    public void SetHealth(int amount)
    {
        curHealth = amount;
        healthBar.SetHealth(amount);
    }
}

