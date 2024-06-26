using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1Scr : EnemyScr
{
#pragma warning disable IDE0044
    private float MoveNum = 93f;  //how far for the sprite to move
    public GameObject collider3;
    public GameObject collider2;


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
        collider3.transform.position = transform.position;
        Debug.Log(transform.position.x);
        Debug.Log("Right");
    }
    public void MovingEnemyL()
    {

        StartCoroutine(Wait());
        Debug.Log(transform.position.x);
        transform.position = new Vector3(transform.position.x - MoveNum * Time.fixedDeltaTime, transform.position.y);
        collider3.transform.position = transform.position;
        Debug.Log(transform.position.x);
        Debug.Log("Left");
    }

    public void Wind()
    {
        meepScr.transform.position = new Vector2(transform.position.x + 5.58f, meepScr.transform.position.y); //shifts the enemy
        collider2.transform.position = meepScr.transform.position;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
