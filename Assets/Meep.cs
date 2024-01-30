using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Meep : MonoBehaviour
{   
    public float Offset = 93f;  //how far for the sprite to move
    private float timeBtwMove = 0;   // a timer that will start every time a move is made and countdown until you are able to move again
    public float StartBtwMove = 1;  //change this so that the time between movements is a conditional for when an enemy has finished their move
    public bool timer = true;  //just checks whether the countdown is complete
    public Button swordAtk;  //links to attacks which are in button form
 
    public LayerMask enemyID;
    public Vector2 positionOfBox;
    public Vector2 sizeOfBox;
    public int damage;
    public bool collide = false;
    public bool left = true;
    public bool right = true;
    public bool stopl = false;
    public bool stopr = false;

    void Start()
    {
        transform.position = new Vector2(0, 0.75f);
    }
    void Update()
    {
        //input
        if ((timeBtwMove <= 0) && (stopr == false))
        {
            timer = true;
            movingCharR();
        }
        if ((timeBtwMove <= 0) && (stopl == false))
        {
            timer = true;
            movingCharL();
        }
        else
        {
            timeBtwMove -= Time.deltaTime;   //timer goes down
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collide = true;
            left = left ? true : false;
            right = right ? true : false;
        }
        if (left == true)
            {
            stopl = true;
        }
        if(right == true)
        {
            stopr = true;
        }
    }

    void movingCharR()
    {

        if (timer == true && (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + Offset * Time.fixedDeltaTime, transform.position.y); //changes the position of sprite
            timeBtwMove = StartBtwMove;  //starts timer
            timer = false; //restarts the timer
            left = false;
            right = true;
            stopl = false;
        }
    }
    void movingCharL()
    {
        if (timer == true && (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.position = new Vector2(transform.position.x - Offset * Time.fixedDeltaTime, transform.position.y); //same set of instructions for moving left
            timeBtwMove = StartBtwMove;
            timer = false;
            left = true;
            right = false;
            stopr = false;

        }
    }
    
    public void attackTime()
    {
        if (Input.GetKey(KeyCode.Mouse1))  //if the user uses right click 
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(positionOfBox, sizeOfBox, 0, enemyID);
            for (int i = 0; i < enemiesToDamage.Length; i++) {
                enemiesToDamage[i].GetComponent<Enemy>().takeDmg(damage);
            }
            timer = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(positionOfBox,sizeOfBox);
    }

}
