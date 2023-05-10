using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
