using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        TopDownMovement player = other.gameObject.GetComponent<TopDownMovement>();

        if (player != null)
        {
            player.ChangeHealth(-player.maxHealth);
            Debug.Log("Mate al parcero " + player.maxHealth + "//" + player.currentHealth);
        }
    }
}
