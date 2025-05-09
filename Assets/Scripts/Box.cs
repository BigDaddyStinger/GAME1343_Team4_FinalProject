using UnityEngine;
using UnityEngine.Events;
public class Box : MonoBehaviour
{
    EventClick eventClick;
    [SerializeField] GameObject healthManager;
    Health health;
    [SerializeField] GameObject destroyedBoxVFX;
    public UnityEvent OnDestroyBox;

    private void Start()
    {
        health = healthManager.GetComponent<Health>();
        eventClick = this.gameObject.GetComponent<EventClick>();

        if (eventClick != null )
        {
            eventClick.OnClick += disableBox;
        }
    }

    private void disableBox(int clicks)
    {
        if (clicks == 1)
        {
            OnDestroyBox?.Invoke();
            Instantiate(destroyedBoxVFX, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Dealed Damage");
            health.DealDamage(10);
        }
        //Instantiate effect at this.gameobject.localposition
    }

}
