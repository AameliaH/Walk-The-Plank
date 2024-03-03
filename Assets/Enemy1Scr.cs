using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1Scr : EnemyScr
{
#pragma warning disable IDE0044
    private float MoveNum = 93f;  //how far for the sprite to move


    // Update is called once per frame
    void Start()
    {
        base.Start();
        transform.position = new Vector2(-3.73f,0.6f);
    }

    public void MovingEnemyR()
    {
        StartCoroutine(Wait());
        Debug.Log(transform.position.x);
        transform.position = new Vector2(transform.position.x + MoveNum * Time.fixedDeltaTime, transform.position.y); //changes position
        Debug.Log(transform.position.x);
        Debug.Log("Right");
    }
    public void MovingEnemyL()
    {

        StartCoroutine(Wait());
        Debug.Log(transform.position.x);
        transform.position = new Vector3(transform.position.x - MoveNum * Time.fixedDeltaTime, transform.position.y);
        Debug.Log(transform.position.x);
        Debug.Log("Left");
    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
