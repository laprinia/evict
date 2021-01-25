using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int HP = 25;
    private GameObject playerHealth;


    private void Start() {
        playerHealth = FindObjectOfType<Health>().gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        playerHealth.GetComponent<Health>().SetHealth(playerHealth.GetComponent<Health>().curHealth + HP);
        Destroy(this.gameObject);
    }
}
