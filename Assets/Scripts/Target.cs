using UnityEngine;

public class Target : MonoBehaviour
{
    EventClick eventClick;

    private void Start()
    {
        eventClick = FindFirstObjectByType<EventClick>();

        if (eventClick != null)
        {
            eventClick.OnClick += disableTarget;
        }
    }

    private void disableTarget(int clicks)
    {
        if (clicks == 3)
        {
            //this.gameObject.SetActive(false);
        }
    }

    //Make Coroutine for reusing Target
}
