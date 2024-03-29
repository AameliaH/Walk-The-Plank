using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collider1Scr : MonoBehaviour
{
    public bool inRange = false;

    public void OnTriggerEnter2D(Collider2D collider) //if collider is triggered 
    {
        if (collider.gameObject.layer == 6)
        {
            inRange = true; //user no longer near the enemy

        }
    }
    public void OnTriggerExit2D(Collider2D collision) //when the collider is no longer being triggered
    {
        inRange = false;
    }
}
