using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Crosshair : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField] UnityEngine.UI.Image crosshair;

    [SerializeField] bool cIsDead;

    [SerializeField] Color crosshairColor;
    [SerializeField] Color crosshairColorClick;

    [SerializeField] float crosshairScale;
    [SerializeField] float crosshairScaleClick;

    public GameObject crosshairCanvas;

    [SerializeField] GameUIManager gameUIManager;

    public void Start()
    {
        crosshairColor = Color.white;
        crosshairScale = 1f;
        crosshairColorClick = Color.red;
        crosshairScaleClick = 1.5f;
        gameUIManager = GameObject.Find("GameUI").GetComponent<GameUIManager>();
        cIsDead = false;
        cIsDead = gameUIManager.isDead;
    }
    public void Update()
    {
        if (!cIsDead)
        {
            crosshairCanvas.SetActive(true);
            mousePos = Input.mousePosition;
            crosshair.transform.position = mousePos;
            //Debug.Log(mousePos.x);
            //Debug.Log(mousePos.y);
        }
        if (Input.GetMouseButtonDown(0))
        {
            crosshair.color = crosshairColorClick;
            crosshair.transform.localScale = new Vector3(crosshairScaleClick, crosshairScaleClick, 1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            crosshair.color = crosshairColor;
            crosshair.transform.localScale = new Vector3(crosshairScale, crosshairScale, 1);
        }
        if (cIsDead)
        {
            crosshairCanvas.SetActive(false);
            crosshair.color = Color.clear;
        }
    }
}
