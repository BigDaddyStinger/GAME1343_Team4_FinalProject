using UnityEngine;

public class JumpPromptTrigger : MonoBehaviour
{
    private GameUIManager ui;

    void Start()
    {
        ui = FindAnyObjectByType<GameUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.ShowActionPrompt("JUMP!");
        }
    }
}
