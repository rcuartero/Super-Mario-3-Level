using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
 : MonoBehaviour
{
    public bool canMove = true;

    private Rigidbody2D rb;
    [SerializeField] private float speed = 2;


    // jumping properties
    [SerializeField] private float jumpStrength = 2;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private bool isGrounded = true;

    
    // State properties
    [SerializeField] private int states = 1;
    /*
    States:
    0 = dead
    1 = small Mario
    2 = large Mario
    3 = tanuki mario
    */

    Coroutine jumpForceChange = null;

    public int lives
    {
        get => _lives;
        set
        {
            //if (_lives < value) // gained a life
            //if (_lives > value) // lost a life

            _lives = value;

        Debug.Log("Lives value has changed to " + _lives.ToString());
            //if (_lives <= 0) // gameover
        }
    }

    private int _lives = 1;

    public int score
    {
        get => _score;
        set
        {
            //if (_lives < value) // gained a life
            //if (_lives > value) // lost a life

            _score = value;

        Debug.Log("Lives value has changed to " + _score.ToString());
            //if (_lives <= 0) // gameover
        }
    }

    private int _score = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //Ground check
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, isGroundLayer);

        if (canMove == true)
        {
            //Gets horizontal movement
            if (Input.GetAxis("Horizontal") != 0)
            {
                rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
            
                //Change scale to change the direction faced
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    transform.localScale = new Vector2(Input.GetAxisRaw("Horizontal"), transform.localScale.y);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
        }
    }   

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            states = 2;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0,0);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Got Hit");
        if (states > 1) states = 1;

        else states = 0;
    }

    public int ReturnState()
    {
        return states;
    }

    public bool ReturnGrounded()
    {
        return isGrounded;
    }

    public void StartJumpForceChange()
    {
        if (jumpForceChange == null)
        {
            jumpForceChange = StartCoroutine(JumpForceChange());
            return;
        }

        StopCoroutine(JumpForceChange());
        jumpForceChange = null;
        jumpStrength /= 2;
        StartJumpForceChange();

    }

    IEnumerator JumpForceChange()
    {
        jumpStrength *= 2;
        yield return new WaitForSeconds(5.0f);
        jumpStrength /= 2;
        jumpForceChange = null;
    }
}