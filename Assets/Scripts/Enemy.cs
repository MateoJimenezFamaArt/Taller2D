using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;

    private Rigidbody2D rb;

    private void Start()
    {
           rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (infoSuelo == false )
        {
            //Girar direccion
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3 (0f, transform.eulerAngles.y + 180, 0f);
        velocidad *= -1f;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position , controladorSuelo.transform.position + Vector3.down * distancia);
    }





    // public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Le pegaste al enemigo");

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        Health health = other.gameObject.GetComponent<Health>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            Debug.Log("Le meti un traque al parcero" + player.maxHealth + "//" + player.currentHealth);
            health.health -= 1;
        }
        if (other.gameObject.tag == "Personaje")
        {

        }

    }
   


    void Die()
    {
       // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
