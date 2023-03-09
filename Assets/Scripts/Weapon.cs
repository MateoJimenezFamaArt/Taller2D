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

        private void Start()
        {
        chorreroMaths = Mathf.Sqrt(Mathf.Pow(fireShotMax.position.x - firePoint.position.x, 2) + Mathf.Pow(fireShotMax.position.y - firePoint.position.y, 2) + Mathf.Pow(fireShotMax.position.z - firePoint.position.z, 2));
        }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
            
        }
    }

    IEnumerator Shoot()
    {



        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, new Vector2(xValue,yValue),chorreroMaths);  
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
