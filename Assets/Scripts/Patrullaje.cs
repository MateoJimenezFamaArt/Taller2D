using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;

    private int SiguientePaso = 0;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int SlimeHit;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[SiguientePaso].position, velocidadMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[SiguientePaso].position) < distanciaMinima)
        {
            SiguientePaso += 1;
            if (SiguientePaso >= puntosMovimiento.Length)
            {
                SiguientePaso = 0;
            }
            Girar();
        }
    }

    private void Girar()
    {
        if (transform.position.x < puntosMovimiento[SiguientePaso].position.x)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        TopDownMovement player = other.gameObject.GetComponent<TopDownMovement>();

        if (player != null)
        {
            player.ChangeHealth(SlimeHit) ;
            Debug.Log("Le meti un traque al parcero" + player.maxHealth + "//" + player.currentHealth);

        }
    }
}
