using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    private int states = 1;

    /*
    States:
    0 = dead
    1 = small Mario
    2 = large Mario
    3 = tanuki mario
    */

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        if (states > 1) states = 1;

        else states = 0;
    }

    public void StateChange(int i)
    {

    }
}
