using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    int numClicks;
    public Action<int> OnClick { get; internal set; }

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
        numClicks++;
        if (numClicks == 4)
        {
            numClicks = 1;
        }
        OnClick?.Invoke(numClicks);
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
