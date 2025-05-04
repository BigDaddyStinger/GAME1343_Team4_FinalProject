using UnityEngine;

public class Table : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Damage
        }
    }
}
