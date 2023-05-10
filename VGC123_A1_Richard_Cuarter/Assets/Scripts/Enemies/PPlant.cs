using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PPlant : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private bool isMoving = true;

    // shooting stuff
    [SerializeField] private GameObject bullet; 
    [SerializeField] private float bulletSpd;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float timeCheck;
    [SerializeField] private float cooldown;

    // tracking
    [SerializeField] private Transform player;

    // animation stuff
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
        }

        if (Time.time - timeCheck > cooldown && isMoving == false)
        {
            Fire();
        }

        else if (Time.time - timeCheck > 5 && isMoving == true)
        {
            Debug.Log("Destroyed");
            //Destroy(this);
        }

        //Animation stuff
        if (player.position.y > bulletSpawn.position.y)
        {
            anim.SetBool("faceDown", false);
        }
        else
        {
            anim.SetBool("faceDown", true);
        }

        // flip the scale if player is to the right of the PPlant
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector2 (-1, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2 (1, transform.localScale.y);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.transform.tag == "Platform")
        {
            timeCheck = Time.time;
            isMoving = false;
            rb.velocity = new Vector2(0,0);
        }
    }

    void Fire()
    {
        bullet = Instantiate(bullet, bulletSpawn);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = bulletSpawn.transform.position;

        if (player.position.x < transform.position.x)
        {
            brb.velocity = new Vector2(-bulletSpd * Time.fixedDeltaTime, brb.velocity.y);
        }

        else
        {
            brb.velocity = new Vector2(bulletSpd * Time.fixedDeltaTime, brb.velocity.y);
        }

        if (player.position.y < bulletSpawn.position.y)
        {
            brb.velocity = new Vector2(brb.velocity.x, -bulletSpd * Time.fixedDeltaTime);
        }

        else
        {
            brb.velocity = new Vector2(brb.velocity.x, bulletSpd * Time.fixedDeltaTime);
        }

        bullet.transform.SetParent(null);
        isMoving = true;
        speed = -speed;
        timeCheck = Time.time;
    }
}
