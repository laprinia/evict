using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    public GameObject leftClickPortal;
    public GameObject rightClickPortal;
    public GameObject player;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ShootPortalA(leftClickPortal);
            leftClickPortal.transform.position = Vector3.MoveTowards(leftClickPortal.transform.position, player.transform.position, 0.03f);
            leftClickPortal.GetComponentInChildren<Animator>().Play("openDoors", -1, 0f);
            leftClickPortal.GetComponent<Animator>().Play("SpawnPortal", -1, 0f);
        }
        else if (Input.GetMouseButtonDown(1)) {
            ShootPortalB(rightClickPortal);
            rightClickPortal.transform.position = Vector3.MoveTowards(rightClickPortal.transform.position, player.transform.position, 0.03f);
            rightClickPortal.GetComponentInChildren<Animator>().Play("openDoors", -1, 0f);
            rightClickPortal.GetComponent<Animator>().Play("SpawnPortalB", -1, 0f);
        }
    }

    void ShootPortalA(GameObject portal) {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo)) {
            if (hitInfo.collider.tag == "SurfaceForPortal") {
                Quaternion findNormal = Quaternion.LookRotation(hitInfo.normal);
                if (findNormal.eulerAngles.x == 0) {
                    portal.transform.position = new Vector3(hitInfo.point.x, hitInfo.collider.gameObject.GetComponent<Renderer>().bounds.center.y, hitInfo.point.z); // + hitInfo.transform.forward * 0.1f;
                } else {
                    portal.transform.position = hitInfo.point;
                }
                portal.transform.rotation = findNormal;
            }
        }
    }

    void ShootPortalB(GameObject portal) {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo)) {
            if (hitInfo.collider.tag == "SurfaceForPortal") {
                Quaternion findNormal = Quaternion.LookRotation(hitInfo.normal);
                if (findNormal.eulerAngles.x == 0) {
                    portal.transform.position = new Vector3(hitInfo.point.x, hitInfo.collider.gameObject.GetComponent<Renderer>().bounds.center.y, hitInfo.point.z); // + hitInfo.transform.forward * 0.1f;
                } else {
                    portal.transform.position = hitInfo.point;
                }
                portal.transform.rotation = findNormal;

                Vector3 dirFromAtoB = (portal.transform.position - player.transform.position).normalized;
                float dotProd = Vector3.Dot(dirFromAtoB, player.transform.forward);

                if (portal.transform.rotation.x != 0) {
                    Vector3 rot = portal.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x + 180, rot.y, rot.z);
                    portal.transform.rotation = Quaternion.Euler(rot);
                } else {
                    if (dotProd > 0) {

                        Vector3 rot = portal.transform.rotation.eulerAngles;
                        rot = new Vector3(rot.x, rot.y + 180, rot.z);
                        portal.transform.rotation = Quaternion.Euler(rot);
                    }
                }
            }

        }
    }
}
