using UnityEngine;

public class RocksDisabler : MonoBehaviour
{
    public bool rocksDisabled { get; private set; }

    private void Start()
    {
        rocksDisabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rocksDisabled = true;
        }
    }
}
