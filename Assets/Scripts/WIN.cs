using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    public GameObject player;
    public GameObject portalA;
    public GameObject portalB;
    public GameObject placeForPortalA;
    public GameObject placeForPortalB;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            player.GetComponent<CreatePortal>().enabled = false;
            portalA.transform.position = placeForPortalA.transform.position;
            portalB.transform.position = placeForPortalB.transform.position;
            portalA.transform.rotation = placeForPortalA.transform.rotation;
            portalB.transform.rotation = placeForPortalB.transform.rotation;
        }
    }
}
