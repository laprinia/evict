using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{
    public GameObject leftClickPortal;
    public GameObject rightClickPortal;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ShootPortal(leftClickPortal);
        }
        else if (Input.GetMouseButtonDown(1)) {
            ShootPortal(rightClickPortal);
        }
    }

    void ShootPortal(GameObject portal) {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;

        if(Physics.Raycast(rayOrigin, out hitInfo)) {
            Quaternion findNormal = Quaternion.LookRotation(hitInfo.normal);
            portal.transform.position = hitInfo.point;
            portal.transform.rotation = findNormal;
        }
    }
}
