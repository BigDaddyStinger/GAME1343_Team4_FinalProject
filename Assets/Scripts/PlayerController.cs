using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{

    CharacterController playerController;
    [SerializeField] GameObject playerCamera;
    [SerializeField] Rigidbody playerRigidBody;


    [SerializeField] float playerSpeed = 1.0f;
    [SerializeField] float playerJumpForce = 1.0f;
    [SerializeField] float playerLookSensitivityX = 1.0f;
    [SerializeField] float playerLookSensitivityY = 1.0f;

    Vector2 movementInput;
    bool grounded;
    float xRotation;

    InputAction playerMovement;
    InputAction playerJump;

    void OnEnable()
    {
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = InputSystem.actions.FindAction("Move");
        playerJump = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    public void OnMove()
    {
        Debug.Log("I AM MOVING");
        Vector2 moveValue = playerMovement.ReadValue<Vector2>() * playerSpeed * Time.deltaTime;
        transform.Translate(moveValue.x, 0, moveValue.y);
    }

    public void UpdateMovement()
    {
        OnMove();
    }

    void OnJump()
    {
        playerRigidBody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
    }

}
