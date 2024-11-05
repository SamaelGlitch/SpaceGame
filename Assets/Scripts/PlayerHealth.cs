using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el jugador choca con un "Bullet" o "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Contacto con Enemigo");
            TakeDamage(1); // Llama a la función de daño y reduce la vida en 1
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Perdi 1 vida");
        if (health <= 0)
        {
            Destroy(gameObject); // Destruye el jugador si la vida llega a 0
        }
    }
    public int GetCurrentHealth()
    {
        return health;
    }
}
