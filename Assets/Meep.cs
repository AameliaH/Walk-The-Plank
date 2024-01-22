using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meep : MonoBehaviour
{   
    public float Offset = 92f;  //how far for the sprite to move
    private float timeBtwMove = 0;   // a timer that will start every time a move is made and countdown until you are able to move again
    public float StartBtwMove = 5;  //change this so that the time between movements is a conditional for when an enemy has finished their move
    public bool timer = true;  //just checks whether the countdown is complete
    public Button swordAtk;  //links to attacks which are in button form
 
    public LayerMask enemyID;
    public Vector2 positionOfBox;
    public Vector2 sizeOfBox;

    void Start()
    {
        transform.position = new Vector2(0, 0.75f);
    }
    void Update()
    {
        //input
        if (timeBtwMove <= 0)
        {
            timer = true;
            movingChar();
            attackTime();
        }
        else
        {
            timeBtwMove -= Time.deltaTime;   //timer goes down
        }
    }
    void movingChar()
    {

        if (timer == true && (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + Offset * Time.fixedDeltaTime, transform.position.y); //changes the position of sprite
            timeBtwMove = StartBtwMove;  //starts timer
            timer = false; //restarts the timer
        }

        if (timer == true && (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.position = new Vector2(transform.position.x - Offset * Time.fixedDeltaTime, transform.position.y); //same set of instructions for moving left
            timeBtwMove = StartBtwMove;  
            timer = false;
        }
    }
    void attackTime()
    {
        if (Input.GetKey(KeyCode.Mouse1))  //if the user uses right click 
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(positionOfBox, sizeOfBox, 0, enemyID);
        }
    }
    


}
