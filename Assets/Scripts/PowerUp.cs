using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float newMass = .5f;
    [SerializeField] float powerDuration = 3;
    private float originalMass;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(GravityPowerUp(other.gameObject));
        }
    }

    IEnumerator GravityPowerUp(GameObject player)
    {
        float mass = player.transform.GetComponent<Rigidbody>().mass;
        originalMass = mass;
        player.transform.GetComponent<Rigidbody>().mass = newMass;

        yield return new WaitForSeconds(powerDuration);

        player.transform.GetComponent<Rigidbody>().mass = originalMass;
  
    }
}
