using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHealth : MonoBehaviour
{
    [SerializeField] private float health;


    // Update is called once per frame
    public void TomarDmg (float damage)
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
        AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.EnemyDie);
        Destroy(gameObject);
    }
}
