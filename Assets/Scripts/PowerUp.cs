using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float newMass = .5f;
    [SerializeField] float powerDuration = 3;
    private float originalMass;
    public UnityEvent OnPowerUp;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnPowerUp?.Invoke();
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
