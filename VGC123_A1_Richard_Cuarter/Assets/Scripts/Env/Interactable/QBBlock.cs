using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class QBBlock : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject collectible;

    private void Start() 
    {
        animator =  GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Player" && other.transform.position.y < transform.position.y && Mathf.Abs(other.transform.position.x - transform.position.x) < GetComponent<BoxCollider2D>().size.x/1.5)
        {
            animator.SetBool("bumped", true);
        }
    }

    public void SpawnCollectible()
    {
        GameObject spawnedCol = Instantiate(collectible, transform);
        spawnedCol.transform.position = transform.position;
        spawnedCol.transform.SetParent(null);
    }
}
