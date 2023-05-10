using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement pm;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb =  gameObject.GetComponent<Rigidbody2D>();
        pm = gameObject.GetComponent<PlayerMovement>();
        anim =  gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is grounded, animator is grounded
        anim.SetBool("isGrounded", pm.ReturnGrounded());

        anim.SetFloat("isMoving", Mathf.Abs(Input.GetAxis("Horizontal")));

        anim.SetInteger("states", pm.ReturnState());
    }
}
