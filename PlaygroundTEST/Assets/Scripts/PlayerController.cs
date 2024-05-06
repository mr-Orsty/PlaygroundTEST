using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float moveSpeed = 2.0f;
    float horizontalInput;
    float verticalInput;
    private Vector3 moveDirection;

    [SerializeField] private float _velocity;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float checkGroundRadius = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if(IsOnTheGround())
        {
            _velocity = -2;
        }

        DoGravity();
    }

    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(_groundChecker.position, checkGroundRadius, _groundMask);

        return result;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        moveDirection.y -= 9.81f * Time.deltaTime;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }
}