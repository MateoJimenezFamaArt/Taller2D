using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{


    [SerializeField] private Vector2 velocidadMovimiento;

    [SerializeField] private Vector2 offset;

    [SerializeField] Material material;

    [SerializeField] private Rigidbody2D playerRB;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Personaje").GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        offset = (playerRB.velocity.x * 0.1f) * velocidadMovimiento*Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
