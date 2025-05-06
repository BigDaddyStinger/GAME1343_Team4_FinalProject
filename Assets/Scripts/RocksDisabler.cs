using UnityEngine;

public class RocksDisabler : MonoBehaviour
{
    [SerializeField] GameObject rocksSpawner1;
    [SerializeField] GameObject rocksSpawner2;
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
            rocksSpawner1.SetActive(false);
            rocksSpawner2.SetActive(false);
        }
    }
}
