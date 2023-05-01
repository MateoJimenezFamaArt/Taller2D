using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHealth : MonoBehaviour
{
    public int health = 100;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Le pegaste al enemigo");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
