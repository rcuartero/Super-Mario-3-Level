using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class Mushroom : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private Transform player;

    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float targetYOffset;
    private Rigidbody2D rb;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos = transform.position + new Vector3(0, targetYOffset);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > targetPos.y)
        {
            isActive = true;
            bc.enabled = true;
            rb.gravityScale = 0.5f;

            if (player.position.x > transform.position.x)
            {
                speed = -speed;
            }
        }

        if (isActive == true)
        {
            rb.velocity = new Vector2(speed * 2, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player")) Destroy(this.gameObject);

        if (other.transform.tag == "Wall")
        {
            speed = -speed;
        }        
    }
}
