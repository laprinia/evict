using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    private float mouseX;
    public float sensitivity = 2.0f;

    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        Vector3 newRotation = _myTransform.localEulerAngles;
        newRotation.y += mouseX * sensitivity;
        _myTransform.localEulerAngles = newRotation;
    }
}
