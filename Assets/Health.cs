using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;

    public HealthBar healthBar;
    public RawImage dieAnim;

    private GameObject player;
    private bool canReceiveDamage = true;

    void Start()
    {
        curHealth = maxHealth;
        player = this.gameObject;
    }

    private void Update() {
        if(curHealth <= 0 && canReceiveDamage) {
            player.GetComponent<FPSController>().enabled = false;
            player.GetComponent<CreatePortal>().enabled = false;
            player.GetComponentInChildren<GUIManager>().enabled = false;
            canReceiveDamage = false;
            dieAnim.gameObject.SetActive(true);
        }
    }

    public void DamagePlayer(int damage) {
        if (curHealth > 0 && canReceiveDamage) {
            curHealth -= damage;

            healthBar.SetHealth(curHealth);
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

