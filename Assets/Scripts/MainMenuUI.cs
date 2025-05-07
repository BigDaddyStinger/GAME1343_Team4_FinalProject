using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Production");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game clicked");
    }
}
