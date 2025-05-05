using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    CharacterController playerController;
    [SerializeField] GameObject playerCamera;
    [SerializeField] Rigidbody playerRigidBody;


    [SerializeField] float playerSpeed = 1.0f;
    [SerializeField] float moveSpeedModifier = 2.0f;
    [SerializeField] float playerJumpForce = 1.0f;
    [SerializeField] float playerLookSensitivityX = 1.0f;
    [SerializeField] float playerLookSensitivityY = 1.0f;
    [SerializeField] public int maxStamina;
    [SerializeField] public int currentStamina;
    [SerializeField] public int points;
    [SerializeField] public int maxAmmo;
    [SerializeField] public int currentAmmo;
    [SerializeField] float time = 0.0f;
    [SerializeField] float tickerTimer = 0.1f;
    [SerializeField] bool isDead;
    [SerializeField] bool isMoving;
    [SerializeField] bool isPaused;
    [SerializeField] bool isGameOver;
    [SerializeField] bool isGrounded;
    

    Vector2 movementInput;
    bool grounded;
    float xRotation;

    InputAction playerMovement;
    InputAction playerJump;
    InputAction playerShoot;
    InputAction playerSprint;
    InputAction playerLook;

    public event Action OnStatsChanged;

    public void OnEnable()
    {
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        playerMovement = InputSystem.actions.FindAction("Move");
        playerJump = InputSystem.actions.FindAction("Jump");
        playerShoot = InputSystem.actions.FindAction("Attack");
        playerSprint = InputSystem.actions.FindAction("Sprint");
        playerLook = InputSystem.actions.FindAction("Look");

        isGameOver = false;
        isDead = false;
        isPaused = false;
        isMoving = false;
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateMovement();
        StaminaTicker();

        time += Time.deltaTime;
    }

    public void OnMove()
    {
        Debug.Log("I AM MOVING");
        Vector2 moveValue = playerMovement.ReadValue<Vector2>() * playerSpeed * Time.deltaTime;
        transform.Translate(moveValue.x, 0, moveValue.y);

        while (moveValue.y == 0)
        {
            moveValue.y = moveSpeedModifier * Time.deltaTime;
            transform.Translate(0, 0, moveValue.y);
        }
    }

    public void UpdateMovement()
    {
        OnMove();
    }

    void OnJump()
    {
        if (isGrounded)
        {
            playerRigidBody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
        }
    }

    public void DamagePlayer()
    {
        currentStamina -= 5;
    }

    public void StaminaTicker()
    {
        if (isDead) return;
        if (time >= tickerTimer) 
        {
            time = time - tickerTimer;
            currentStamina -= 1;
        }
        if (currentStamina <= 0)
        {
            isDead = true;
        }
    }

    public void Died()
    {
        if (isDead)
        {
            isGameOver = true;
        }
    }

    public void GroundedCheck()
    {

    }

}
