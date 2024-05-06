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

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        moveDirection.y -= 9.81f * Time.deltaTime;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
