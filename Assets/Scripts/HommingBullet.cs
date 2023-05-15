using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HommingBullet : MonoBehaviour
{

    public Transform target;
    public float speed = 5;
    public float rotateSpeed = 200f;
    private float BulletTimer;

    private Rigidbody2D rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Personaje").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

       float rotateAmount =  Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (other.gameObject.CompareTag("Personaje"))
        {

            player.ChangeHealth(-1);

            Destroy(gameObject);

        }
    }

}
