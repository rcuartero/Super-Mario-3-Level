using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;
    private float startX;
    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= startX && transform.position.x <= 15.5f && player.transform.position.x >= startX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
