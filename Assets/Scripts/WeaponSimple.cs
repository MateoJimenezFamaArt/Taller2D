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



    private void Start()
    {
        LineVFX.enabled = false;
    }





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
            Debug.Log("Estas intentando disparar");
           

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
                raycastHit2D.transform.GetComponent<ShooterHealth>().TakeDamage(10);
                Instantiate(ImpactFVX, raycastHit2D.point, Quaternion.identity);
                StartCoroutine(LaserShot(raycastHit2D.point));
            }
            else 
            {
                if ((raycastHit2D.transform.CompareTag("Ambiente")))
                {
                    Instantiate(ImpactFVX, raycastHit2D.point, Quaternion.identity);
                    StartCoroutine(LaserShot(raycastHit2D.point));
                }
            }
        }
        else
        {
            Vector3 SinPunto = new Vector3(range, 0, 0) * puntoDisparo.right.x + puntoDisparo.position;
            StartCoroutine(LaserShot(SinPunto));
        }
        AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.Shoot);
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
