using UnityEngine;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
