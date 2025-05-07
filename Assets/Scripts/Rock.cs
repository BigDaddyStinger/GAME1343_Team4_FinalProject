using UnityEngine;

public class Rock : MonoBehaviour
{
    RocksDisabler rocksDisabler;
    Vector3 originalPos;
    [SerializeField] float rockSpeed;
    Health health;
    private void Start()
    {
        health = FindFirstObjectByType<Health>();
        rocksDisabler = FindAnyObjectByType<RocksDisabler>();
        originalPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(0, 0, -1 * rockSpeed * Time.deltaTime);

        if ((rocksDisabler != null) && (rocksDisabler.rocksDisabled == true))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            health.DealDamage(20);
        }
        
        if (other.tag == "Respawn")
        {
            Debug.Log("Respawn");
            transform.position = originalPos;
        }

    }
}
