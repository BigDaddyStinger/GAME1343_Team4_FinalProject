using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JumpPromptTrigger : MonoBehaviour
{
    public GameObject jumpPromptUI;
    private bool isPlayerNear = false;

    void Start()
    {
        if (jumpPromptUI != null)
            jumpPromptUI.SetActive(false); // Hide at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            jumpPromptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            jumpPromptUI.SetActive(false);
        }
    }
}

