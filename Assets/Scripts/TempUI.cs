using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TempUI : MonoBehaviour
{

    [SerializeField] PlayerController playerController;

    [SerializeField] TMP_Text topLeftText;
    [SerializeField] TMP_Text topRightText;
    [SerializeField] TMP_Text bottomCenterText;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            topLeftText.text = "Points: " + playerController.points;
            topRightText.text = "Ammo: " + playerController.currentAmmo + "/" + playerController.maxAmmo;
            bottomCenterText.text = "Stamina: " + playerController.currentStamina + "/" + playerController.maxStamina;
        }
    }
}