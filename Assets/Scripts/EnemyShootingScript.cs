using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Personaje");
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < 5)
        {
            timer += Time.deltaTime;

            if (timer > 1.5f)
            {
                Debug.Log("Bullet Shot");
                timer = 0;
                shoot();
            }
        }
    }


    void shoot()
    {
       AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.EnemyShoot);
        Instantiate(bullet,bulletpos.position,Quaternion.identity);
    }
}
