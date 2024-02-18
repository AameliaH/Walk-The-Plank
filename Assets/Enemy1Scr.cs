using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1Scr : EnemyScr
{
    private float Move = 93f;  //how far for the sprite to move
    private float attackDis = 40f;
    private int health = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(-3.73f,0.6f);
    }

    public void movingEnemyR()
    {
        transform.position = new Vector2(transform.position.x + Move * Time.fixedDeltaTime, transform.position.y); //changes position

    }
    public void movingEnemyL()
    {
        transform.position = new Vector2(transform.position.x - Move * Time.fixedDeltaTime, transform.position.y);
       
    }

    public void EnemyAtk()
    {
        base.EnemyAtk();
        if (meepScr.transform.position.x > transform.position.x)
        {
            StartCoroutine(Wait());
            transform.position = new Vector2(transform.position.x + attackDis * Time.fixedDeltaTime, transform.position.y);
            StartCoroutine(Wait());
            transform.position = new Vector2(transform.position.x - attackDis * Time.fixedDeltaTime, transform.position.y);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
