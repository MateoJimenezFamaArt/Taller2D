using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;
    bool crouch;

    //Invincible and health variables
    public float timeInvincible = 2.0f;
    bool isInvinicble;
    public float invincibleTimer;

    public int maxHealth = 3;
    public int currentHealth;

    private Health health;

    public bool instakill;

     public Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        instakill = false;
       health = GameObject.FindObjectOfType<Health>();
    }

    void Update()
    {
        animator.SetFloat("Speed", horizontalMove);

        if (horizontalMove == 0f)
        {
            animator.SetBool("Still", true);
           // Debug.Log("Still es verdadero // move es " + horizontalMove);
        } else
        {
            animator.SetBool("Still", false);
            Debug.Log("Still es falso (Se esta moviendo) // move es " + horizontalMove);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


        //Timer invencible

        if (isInvinicble)
        {
            invincibleTimer -= Time.deltaTime;

            if (invincibleTimer < 0)
            {
                isInvinicble = false;
            }
        }

        //Death

        if (currentHealth == 0 )
        {
            AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.PlayerDeath);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
            Debug.Log("Mi parcero, te moriste");

        }

        //UI Life
      /*  Health health = gameObject.GetComponent<Health>();
        health.numOfHearts = maxHealth;
        health.health = currentHealth;
      */



    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    //HealthSystem Method
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            //animator.SetTrigger("Hit");
           AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.CharacterHit);

            if (isInvinicble)
            {
                return;
            }

            isInvinicble = true;
            invincibleTimer = timeInvincible;

        } else if(amount > 0)
        {
            AudioManagerScript.instance.PlaySFXs(AudioManagerScript.AudioSamples.CharacterHealthUp);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        health.health = currentHealth;

        Debug.Log ("esta es tu health" + health.health);

        Debug.Log("Panita te hicieron un cambio en la vida " + maxHealth + "/" + currentHealth);


    }

    private void FixedUpdate()
    {
            controller.Move(horizontalMove * Time.deltaTime, crouch, jump);
            jump = false;
    }


}
