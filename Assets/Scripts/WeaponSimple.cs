using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class WeaponSimple : MonoBehaviour
{
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private float range;
    [SerializeField] private GameObject ImpactFVX;
    [SerializeField] private LineRenderer LineVFX;
    [SerializeField] private float LaserTime;


    [SerializeField] public AudioSource audio;
    [SerializeField] public AudioClip LaserSFX;
    

    public void PlaySound()
    {
        audio.PlayOneShot(LaserSFX);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            audio.PlayOneShot(LaserSFX);

        }

    }

    private void Fire()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(puntoDisparo.position, puntoDisparo.right, range);

        if (raycastHit2D)
        {
            if (raycastHit2D.transform.CompareTag("Enemigo"))
            {
                raycastHit2D.transform.GetComponent<Enemy>().TakeDamage(10);
                Instantiate(ImpactFVX, raycastHit2D.point, Quaternion.identity);
                StartCoroutine(LaserShot(raycastHit2D.point));
            }
        }
        else
        {
            Vector3 SinPunto = new Vector3(range, 0, 0) * puntoDisparo.right.x + puntoDisparo.position;
            StartCoroutine(LaserShot(SinPunto));
        }

    }

    IEnumerator LaserShot(Vector3 objetivo)
    {
        LineVFX.enabled = true;
        LineVFX.SetPosition(0, puntoDisparo.position);
        LineVFX.SetPosition(1, objetivo);
        yield return new WaitForSeconds(LaserTime);
        LineVFX.enabled = false;
    }


}
