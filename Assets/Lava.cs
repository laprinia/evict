using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    //fdvnfvnf
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player")) other.GetComponent<Health>().DamagePlayer(100);
    }

}
