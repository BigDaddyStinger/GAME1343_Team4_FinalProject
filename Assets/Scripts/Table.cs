using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] GameObject healthManager;
    Health health;

    private void Start()
    {
        health = healthManager.GetComponent<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health.DealDamage(5);
        }
    }
}
