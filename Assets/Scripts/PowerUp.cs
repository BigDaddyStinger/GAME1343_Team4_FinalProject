using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float newMass = .5f;
    [SerializeField] float powerDuration = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(GravityPowerUp(other.gameObject));
        }
    }

    IEnumerator GravityPowerUp(GameObject player)
    {
        float mass = player.GetComponent<Rigidbody>().mass;
        mass = newMass;

        yield return new WaitForSeconds(powerDuration);

        mass = 1;
    }
}
