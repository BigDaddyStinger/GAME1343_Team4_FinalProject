using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    EventClick eventClick;
    [SerializeField] GameObject healthManager;
    Health health;
    private void Start()
    {
        health = healthManager.GetComponent<Health>();
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
            Debug.Log("Clicked 3 times");
            health.AddStamina(50);
            this.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(activateTarget());
        }
    }

    IEnumerator activateTarget()
    {
        var seconds = Random.Range(5, 10);
        yield return new WaitForSeconds(seconds);
        this.gameObject.transform.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(5);
        {
            if (this.gameObject.transform.GetComponent<MeshRenderer>().enabled == true)
            {
                this.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(activateTarget());
            }
        }
    }
}
