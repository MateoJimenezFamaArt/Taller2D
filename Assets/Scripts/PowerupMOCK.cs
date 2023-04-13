using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMOCK : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>();
        //Debug.Log("Esta funcionando el Trigger: " + collision);
        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(controller.maxHealth);
                Destroy(gameObject);
            }

        }
    }


}
