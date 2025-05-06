using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    EventClick eventClick;

    private void Start()
    {
        eventClick = this.gameObject.GetComponent<EventClick>();
        this.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;

        if (eventClick != null)
        {
            eventClick.OnClick += disableTarget;
        }

        StartCoroutine(activateTarget());
    }

    private void disableTarget(int clicks)
    {
        if (clicks == 3)
        {
            //add stamina
            Debug.Log("Clikced 3 times");
            this.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(activateTarget());
           
        }
    }

    IEnumerator activateTarget()
    {
        Debug.Log("Started Coroutine");
        var seconds = Random.Range(10, 20);
        yield return new WaitForSeconds(seconds);
        this.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
    }
}
