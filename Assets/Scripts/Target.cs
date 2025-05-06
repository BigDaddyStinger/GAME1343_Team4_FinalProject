using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    EventClick eventClick;

    private void Start()
    {
        StartCoroutine(activateTarget());
        this.gameObject.SetActive(false);
        eventClick = this.gameObject.GetComponent<EventClick>();

        if (eventClick != null)
        {
            eventClick.OnClick += disableTarget;
        }
    }

    private void disableTarget(int clicks)
    {
        if (clicks == 3)
        {
            StartCoroutine(activateTarget());
            //add stamina
            this.gameObject.SetActive(false);
          
        }
    }

    IEnumerator activateTarget()
    {
        Debug.Log("Started Coroutine");
        var seconds = Random.Range(8, 15);
        yield return new WaitForSeconds(seconds);
        this.gameObject.SetActive(true);
    }
}
