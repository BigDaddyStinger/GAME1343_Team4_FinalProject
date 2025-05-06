using UnityEngine;

public class Box : MonoBehaviour
{
    EventClick eventClick;

    private void Start()
    {
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
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Damage(20);
        }
        //Instantiate effect at this.gameobject.localposition
    }

}
