using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public enum PickupType
    {
        Powerup = 0,
        Life = 1,
        Score = 2
    }

    public PickupType currentPickup;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement myController = other.gameObject.GetComponent<PlayerMovement>();
            if (!myController) return;

            if (currentPickup == PickupType.Powerup)
            {
                myController.StartJumpForceChange();
                Destroy(gameObject);
                return;
            }

            if (currentPickup == PickupType.Life)
            {
                myController.lives++;
                Destroy(gameObject);
                return;
            }

            // do something in regards to score
            myController.score++;
            Destroy(gameObject);
        }
    }
}
