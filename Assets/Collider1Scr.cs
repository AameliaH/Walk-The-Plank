using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Collider1Scr : MonoBehaviour
{
    public GameObject meep;
    private MeepScr meepScr;


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

}
