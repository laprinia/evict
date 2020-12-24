using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    private float mouseY;
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
        mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = _myTransform.localEulerAngles;
        newRotation.x += - mouseY * sensitivity;
        _myTransform.localEulerAngles = newRotation;
    }
}
