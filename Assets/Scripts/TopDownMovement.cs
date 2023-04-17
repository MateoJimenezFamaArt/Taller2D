using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float speedLimiter = 0.7f;
    [SerializeField] float inputHorizontal;
    [SerializeField] float inputVertical;

    //Invincible and health variables
    public float timeInvincible = 2.0f;
    bool isInvinicble;
    public float invincibleTimer;

    public int maxHealth = 3;
    public int currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (currentHealth == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("Mi parcero, te moriste");
        }
    }

    private void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter; 
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }

    }
     public void ChangeHealth(int amount)
    {
        /*
        if (amount < 0)
        {

           //animator.SetTrigger("Hit");

            if (isInvinicble)
            {
                return;
            }

            isInvinicble = true;
            invincibleTimer = timeInvincible;

        }
        */

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log("Panita te hicieron un cambio en la vida " + maxHealth + "/" + currentHealth);
    }

}
