using UnityEngine;

public class Rock : MonoBehaviour
{
    RocksDisabler rocksDisabler;
    Vector3 originalPos;
    [SerializeField] float rockSpeed;
    private void Start()
    {
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
        Debug.Log("Collision");
        if (other.tag == "Player")
        {
            // do damage 
        }
        
        if (other.tag == "Respawn")
        {
            Debug.Log("Respawn");
            transform.position = originalPos;
        }

    }
}
