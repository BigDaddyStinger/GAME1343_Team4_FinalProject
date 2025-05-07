using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject healthManager; //
    Health health; //

    [Header("Stamina")]
    public Image staminaFill;
    public float maxStamina = 100f;
    //public float currentStamina;

    [Header("Wall Warning Flash")]
    public Image wallWarning;
    public float wallFlashDuration = 0.3f;

    [Header("Action Prompt")]
    public TextMeshProUGUI actionPrompt;
    public float promptDuration = 1.5f;

    [Header("Death Screen")]
    public GameObject deathPanel;

    public bool isDead = false;

    void Start()
    {
        health = healthManager.GetComponent<Health>(); //

        health.currentStamina = maxStamina; //
        UpdateStaminaBar();
        wallWarning.enabled = false;
        actionPrompt.gameObject.SetActive(false);
        deathPanel.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;

        // Debug auto-drain
        //health.currentStamina -= Time.deltaTime * 5f; //
        UpdateStaminaBar();

        if (health.currentStamina <= 0) //
        {
            HandleDeath();
        }
    }

    public void UpdateStaminaBar()
    {
        float fill = Mathf.Clamp01(health.currentStamina / maxStamina); //
        staminaFill.fillAmount = fill;
        staminaFill.color = Color.Lerp(Color.red, Color.green, fill);
    }

    public void TriggerWallWarning()
    {
        StartCoroutine(FlashWallWarning());
    }

    private IEnumerator FlashWallWarning()
    {
        wallWarning.enabled = true;
        yield return new WaitForSeconds(wallFlashDuration);
        wallWarning.enabled = false;
    }

    public void ShowActionPrompt(string message)
    {
        StartCoroutine(PromptRoutine(message));
    }

    private IEnumerator PromptRoutine(string msg)
    {
        actionPrompt.text = msg;
        actionPrompt.gameObject.SetActive(true);
        yield return new WaitForSeconds(promptDuration);
        actionPrompt.gameObject.SetActive(false);
    }

    public void HandleDeath()
    {
        isDead = true;
        deathPanel.SetActive(true);
        Time.timeScale = 0f; // Freeze game
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

