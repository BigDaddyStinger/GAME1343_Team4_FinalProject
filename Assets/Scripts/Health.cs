using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    void Update()
    {
        currentStamina -= Time.deltaTime * 5f;
    }
    public void DealDamage(float damage)
    {
        currentStamina -= damage;
    }

    public void AddStamina(float stamina)
    {
        currentStamina += stamina;
    }
}
