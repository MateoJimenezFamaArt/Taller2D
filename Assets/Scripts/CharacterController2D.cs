using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Force of the jump
    [Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;           // Amount of maxSpeed player can reach to crouching movement. 1 = 100%
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement Different way of smoothing out the movement to make it feel better
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping; Should allways be true tho
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character 
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded. 
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings 
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching and also send the animator signal and do other stuff Must EDIT (KindaGotIt)

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded Stay
    private bool m_Grounded;            // Whether or not the player is grounded. Good
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up Good
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing. Great for shooting
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circle is casted to the groundcheck position, by hitting anything designated as ground the player will interact to it as ground
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); //Circlecast to check
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true; // Checks if the collider is hitting against any of the other extra layers
                if (!wasGrounded) // If the player is not grounded send event of I am falling
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //This if shows that the player must be grounded or the air control is activated
        if (m_Grounded || m_AirControl)
        {

            // If crouching set active the crouch state
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier if 0 there will be no crouch movement 
                move *= m_CrouchSpeed;

                /*
                // Disable one of the colliders when crouching
                //Add an extra feature where once crouching there is an animator signal being sent in order to do the crouch animation
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
                */
            }
            else
            {
                /*
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
                */

                if (m_wasCrouching) // Send the signal that the crouching state is no more
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // Makes the player correct the view he is giving out
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Makes the player correct the view by checking
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player is on the ground and jump is true then add vertical force
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Rotate the players spirte rotation in order to make everything turn arround and look better
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);


    }
}
