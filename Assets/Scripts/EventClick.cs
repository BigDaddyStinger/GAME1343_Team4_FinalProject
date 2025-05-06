using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    int clickCount;

    public UnityAction<int> OnClick;

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
        //this.gameObject.SetActive(false);
        Debug.Log("Clicked");

        clickCount++;
        if (clickCount == 4)
        {
            clickCount = 1;
        }
        OnClick?.Invoke(clickCount);
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
