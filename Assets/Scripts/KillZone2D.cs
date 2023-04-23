using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement playerr = other.gameObject.GetComponent<PlayerMovement>();

        if (playerr != null)
        {
            playerr.ChangeHealth(-playerr.maxHealth);
            playerr.instakill = true;
            Debug.Log("Mate al parcero " + playerr.maxHealth + "//" + playerr.currentHealth);
        }
    }


}
