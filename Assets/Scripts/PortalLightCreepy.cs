using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLightCreepy : MonoBehaviour
{
    public Renderer portal;
    Material neonLight;

    private void Start() {
        neonLight = portal.material;
        StartCoroutine(Flash());
    }

    void Update()
    {

    }

    IEnumerator Flash() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0, 15));
            neonLight.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(.2f);
            neonLight.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(.1f);
            neonLight.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(.2f);
            neonLight.EnableKeyword("_EMISSION");
        }
    }
}
