using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    EventClick eventClick;
    [SerializeField] GameObject healthManager;
    Health health;
    [SerializeField] GameObject staminaVFX;
    public UnityEvent OnGainStamina;
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
            OnGainStamina?.Invoke();
            health.AddStamina(50);
            Instantiate(staminaVFX, transform.position, Quaternion.identity);
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
