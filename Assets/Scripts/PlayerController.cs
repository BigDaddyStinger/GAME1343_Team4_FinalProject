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
    //[SerializeField] float playerLookSensitivityX = 1.0f;
    //[SerializeField] float playerLookSensitivityY = 1.0f;
    [SerializeField] float time = 0.0f;
    //[SerializeField] float tickerTimer = 0.1f;
    [SerializeField] float groundCheckDistance = 1.0f;
    [SerializeField] float onLevelCheckDistance = 150.0f;
    [SerializeField] float onLevelElapsedTime = 0.0f;
    [SerializeField] float onLevelKillTimer = 0.0f;
    [SerializeField] float triggerElapsedTime = 0.0f;
    [SerializeField] float triggerResetTimeAmmount = 0.5f;
    [SerializeField] float deathBoolResetTimer = 1.0f;
    [SerializeField] float deathBoolResetElapsedTime = 1.0f;

    [SerializeField] public int maxStamina;
    [SerializeField] public int currentStamina;
    [SerializeField] public int points;
    [SerializeField] public int maxAmmo;
    [SerializeField] public int currentAmmo;

    [SerializeField] bool pcIsDead;
    [SerializeField] bool pcIsMoving;
    [SerializeField] bool pcIsPaused;
    [SerializeField] bool pcIsGameOver;
    [SerializeField] bool pcIsVictory;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isOnLevel;

    [SerializeField] LayerMask Ground;

    Vector2 movementInput;

    InputAction playerMovement;
    InputAction playerJump;
    InputAction playerShoot;
    InputAction playerSprint;
    InputAction playerLook;

    //public event Action OnStatsChanged;

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
        //playerLook = InputSystem.actions.FindAction("Look");

        pcIsGameOver = false;
        pcIsPaused = false;
        pcIsMoving = false;



        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        UpdateMovement();
       // StaminaTicker();
        GroundCheck();
        PlayAreaCheck();
        TriggerDeathAnimation();

        time += Time.deltaTime;
        pcIsDead = GameObject.Find("GameUI").GetComponent<GameUIManager>().isDead;
    }

    public void OnMove()
    {
        if (pcIsDead)
        {
            return;
        }
        if (!pcIsDead)
        {
            //Debug.Log("I AM MOVING");
            Vector2 moveValue = playerMovement.ReadValue<Vector2>() * playerSpeed * Time.deltaTime;
            float magnitude = moveValue.magnitude;
            transform.Translate(moveValue.x, 0, moveValue.y);

            if (moveValue.y == 0)
            {
                moveValue.y = moveSpeedModifier * Time.deltaTime;
                transform.Translate(0, 0, moveValue.y);
            }

            if (magnitude >= 0.0f && magnitude < 0.01f && isGrounded)
            {
                playerAnimator.SetBool("isWalking", true);
                playerAnimator.SetBool("isRunning", false);
            }

            else if (magnitude >= 0.01f && isGrounded)
            {
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isRunning", true);
            }

            else
            {
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isRunning", false);
            }
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
            playerAnimator.SetTrigger("isJumping");
        }
    }

    // Old gain and decreese stamina for temp ui
   /*
    * public void DamagePlayer()
    {
        currentStamina -= 5;
    }

    public void HealPlayer()
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
            pcIsGameOver = true;
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

    public void JumpTriggerReset()
    {
        if (!isGrounded)
        {
            triggerElapsedTime += Time.deltaTime;
            if (triggerElapsedTime >= triggerResetTimeAmmount)
            {
                playerAnimator.ResetTrigger("isJumping");
            }
        }
    }

    public void TriggerVictoryAnimation()
    {
        playerAnimator.SetBool("isVictory", true);
    }

    public void TriggerDeathAnimation()
    {
        if(!pcIsDead)
        {
            return;
        }
        if (pcIsDead)
        {
            playerAnimator.SetBool("isDead", true);
            deathBoolResetElapsedTime += Time.deltaTime;
        }
        if (deathBoolResetElapsedTime > deathBoolResetTimer)
        {
            playerAnimator.SetBool("isDead", false);
        }
    }
}
