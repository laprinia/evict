using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject otherPortal;

     void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerTag") {
            GameObject clone = (GameObject)Instantiate(other.gameObject, otherPortal.transform.position + otherPortal.transform.forward * 1, otherPortal.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
