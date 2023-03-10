using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    [SerializeField] private Transform fireShotMax ;
    public int damage = 20;
    public GameObject impactEffect;
    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField] private float timeBullet,xValue,yValue;
    float chorreroMaths;
    public Vector2 VectorDirector;

        private void Start()
        {
        chorreroMaths = Mathf.Sqrt(Mathf.Pow(fireShotMax.position.x - firePoint.position.x, 2) + Mathf.Pow(fireShotMax.position.y - firePoint.position.y, 2) + Mathf.Pow(fireShotMax.position.z - firePoint.position.z, 2));
        VectorDirector = new Vector2(xValue, yValue);
        }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());

        }

        if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            xValue = 1; yValue = 0;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            xValue = -1; yValue = 0;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKeyDown(KeyCode.W)) //Up
        {
            xValue = 0; yValue = 1;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) //Up Right
        {
            xValue = 1; yValue = 1;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) //Up Left
        {
            xValue = -1; yValue = 1;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) //Down Right
        {
            xValue = 1; yValue = -1;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) //Down Left
        {
            xValue = -1; yValue = -1;
            fireShotMax.localPosition = fireShotMax.localPosition * VectorDirector;
            Debug.Log("Disparo a en: " + xValue + "//" + yValue);
        }

        VectorDirector.Set(xValue, yValue);
        Debug.Log(fireShotMax.localPosition);
    }

    IEnumerator Shoot()
    {



        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,VectorDirector,chorreroMaths);  
        if (hitInfo)
        {
         Enemy enemy =   hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Metiste un balaso");
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            

            lineRenderer.SetPosition(0,firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);


        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1,fireShotMax.position); 
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(timeBullet); 

       lineRenderer.enabled=false;


         }


}
