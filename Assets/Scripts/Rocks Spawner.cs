using UnityEngine;
using System.Collections;

public class RocksSpawner : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float waitSeconds1;
    [SerializeField] float waitSeconds2;

    private void Start()
    {
        StartCoroutine(RockSpawn());
    }

    IEnumerator RockSpawn()
    {
        yield return new WaitForSeconds(waitSeconds1);
        Instantiate(rockPrefab, spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitSeconds2);
        Instantiate(rockPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
