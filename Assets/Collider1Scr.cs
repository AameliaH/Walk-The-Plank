using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collider1Scr : MonoBehaviour
{
    public GameObject meep;
    private MeepScr meepScr;
    public BoxCollider2D Collider1;
    public bool inRange = false;


    private void Awake()
    {
        meepScr = meep.GetComponent<MeepScr>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collider) //if collider is triggered 
    {
        if (collider.gameObject.layer == 6)
        {
            inRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision) //when the collider is no longer being triggered
    {
        inRange = false;
    }
}
