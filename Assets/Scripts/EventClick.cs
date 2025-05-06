using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Empty
    }
}
