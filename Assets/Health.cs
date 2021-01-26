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
    public float knockBackForce = 10;

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

    public void DamagePlayer(int damage, GameObject enemyHit = null) {
        if (curHealth > 0 && canReceiveDamage) {
            if (enemyHit != null) {
                Vector3 hurtDirection = (player.transform.position - enemyHit.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
                player.GetComponent<ForceReceiver>().AddForce(knockbackDirection, knockBackForce);
            }

            curHealth -= damage;

            healthBar.SetHealth(curHealth);
        }
    }

    public void HealPlayer(int heal)
    {
        if (curHealth < maxHealth)
        {
            curHealth += heal;
            healthBar.SetHealth(curHealth);
        }
       
    }

    public void SetHealth(int amount)
    {
        curHealth = amount;
        healthBar.SetHealth(amount);
    }
}

