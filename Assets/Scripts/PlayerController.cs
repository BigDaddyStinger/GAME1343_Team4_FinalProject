using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;
using System;
using System.Collections;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{

    CharacterController playerController;

    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject pcGameUIManager;
    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Animator playerAnimator;


    [SerializeField] float playerSpeed = 1.0f;
    [SerializeField] float moveSpeedModifier = 2.0f;
    [SerializeField] float playerJumpForce = 1.0f;
    [SerializeField] float playerLookSensitivityX = 1.0f;
    [SerializeField] float playerLookSensitivityY = 1.0f;
    [SerializeField] float time = 0.0f;
    [SerializeField] float tickerTimer = 0.1f;
    [SerializeField] float groundCheckDistance = 1.0f;
    [SerializeField] float onLevelCheckDistance = 150.0f;
    [SerializeField] float onLevelElapsedTime = 0.0f;
    [SerializeField] float onLevelKillTimer = 0.0f;

    [SerializeField] public int maxStamina;
    [SerializeField] public int currentStamina;
    [SerializeField] public int points;
    [SerializeField] public int maxAmmo;
    [SerializeField] public int currentAmmo;

    [SerializeField] bool pcIsDead;
    [SerializeField] bool isMoving;
    [SerializeField] bool isPaused;
    [SerializeField] bool isGameOver;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isOnLevel;

    [SerializeField] LayerMask Ground;

    Vector2 movementInput;

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
        isPaused = false;
        isMoving = false;

        pcIsDead = GameObject.Find("GameUI").GetComponent<GameUIManager>().isDead;

        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateMovement();
       // StaminaTicker();
        GroundCheck();
        PlayAreaCheck();

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

    // Old gain and decreese stamina for temp ui
   /*
    * public void DamagePlayer()
    {
        currentStamina -= 5;
    }

    public void HealPlayer()
    {
        currentStamina += 5;
    }
   */

    // Old Ticker for temp ui
    /*
     * public void StaminaTicker()
    {
        if (pcIsDead) return;
        if (time >= tickerTimer)
        {
            time = time - tickerTimer;
            currentStamina -= 1;
        }
        if (currentStamina <= 0)
        {
            pcIsDead = true;
        }
    }
    */

    public void Died()
    {
        if (pcIsDead)
        {
            isGameOver = true;
        }
    }

    public void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void PlayAreaCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, onLevelCheckDistance))
        {
            isOnLevel = true;
        }
        else
        {
            isOnLevel = false;
        }
        if (!isOnLevel)
        {
            onLevelElapsedTime += Time.deltaTime;
            if (onLevelElapsedTime >= onLevelKillTimer)
            {
                pcIsDead = true;
            }
        }
    }
}
