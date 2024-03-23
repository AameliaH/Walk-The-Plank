using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider3Scr : MonoBehaviour
{
    public bool inRange = false;
    public bool temp = false;
    public GameObject collider3;

    public void OnTriggerEnter2D(Collider2D collider) //if collider is triggered 
    {
        Debug.Log("collide1");
        if (collider.gameObject.layer == 7)
        {
            Debug.Log("collide2");
            inRange = true; //user no longer near the enemy

        }
    }
    public void OnTriggerExit2D(Collider2D collision) //when the collider is no longer being triggered
    {
        inRange = false;
    }
}
