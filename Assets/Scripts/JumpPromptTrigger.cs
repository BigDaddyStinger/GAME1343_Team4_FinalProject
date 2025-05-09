using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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
            StartCoroutine(ShowPrompt());
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            jumpPromptUI.SetActive(false);
        }
    }*/

    IEnumerator ShowPrompt()
    {
        jumpPromptUI.SetActive(true);
        yield return new WaitForSeconds(3);
        jumpPromptUI.SetActive(false);
        isPlayerNear = false;
    }
}

