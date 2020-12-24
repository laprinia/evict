using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PortalTraveller
{
    public float speed = 5.0f;
    public float jumpHeight = 10;
    public float gravity = 20;
    
    private Vector3 _moveDirection = Vector3.zero;
    private CharacterController _controller;

    private void Start() {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void CalculateMovement() {
        if (_controller.isGrounded) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _moveDirection = new Vector3(h, 0, v);
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= speed;
            if (Input.GetButtonDown("Jump")) {
                _moveDirection.y = jumpHeight;
            }
        }
        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }
}
