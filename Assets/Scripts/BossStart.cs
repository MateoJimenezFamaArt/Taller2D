using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Personaje"))
        {
            AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.BossStart);
        }
    }

}
