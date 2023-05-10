using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RKoopaBehavior : MonoBehaviour
{
    //walking stuff
    private Rigidbody2D rb;
    [SerializeField] private float spd = -0.4f;

    //edge detector
    [SerializeField] private BoxCollider2D ed;

    //states walking/shell
    private bool isWalking = true;
    [SerializeField] private float shellSpd = -2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ed) Debug.Log("need an edge Collider");

        if (isWalking == true) rb.velocity = new Vector2 (spd, rb.velocity.y);

        if (isWalking == false) return;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Platform")) 
        {
            Debug.Log("Edge of platform");
            transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
            spd = -spd;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
            spd = -spd;
        }
    }

}
