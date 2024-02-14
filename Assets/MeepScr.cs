using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MeepScr : MonoBehaviour
{
    public float Move = 93f;  //how far for the sprite to move
    private float timeBtwMove = 0;   // a timer that starts every time a move is made 
    public float StartBtwMove = 1;  //how long the timer is
    public bool timer = true;  //just checks whether the countdown is complete
    public Button swordAtk;  //links to attacks which are in button form
    public int atkTimer = 0;
    public GameObject enemyObj;
    public GameObject collideObj;
    public Vector2 swordPos;
    private EnemyScr enemyScr;
    public Collider1Scr collider1Scr;  
    public bool swordActive = false;
    private Vector2 meepPos;
    
    public int damage;
    [SerializeField] LayerMask enemyID;  //serialize field is private but can see in investigator
    [SerializeField] Vector2 positionOfBox;
    [SerializeField] Vector2 sizeOfBox;
    public bool collide = false;
    public bool left = true;
    public bool right = true;
    public bool stopL = false;
    public bool stopR = false;

    private void Awake()
    {
        collider1Scr = collideObj.GetComponent<Collider1Scr>(); //gets the script from object
        enemyScr = enemyObj.GetComponent<EnemyScr>();
        transform.position = new Vector2(0, 0.75f); //sets position of user
    }

    private void Start()
    {
        Debug.Log("Health is " + enemyScr.health);
    }

    void Update()
    {
        if ((timeBtwMove <= 0) && (stopR == false)) //if timer is done + no stop flag
        {
            movingCharR();  //calls function
        }
        if ((timeBtwMove <= 0) && (stopL == false))
        {
            movingCharL();
        }
        else
        {
            timeBtwMove -= Time.deltaTime;   //timer goes down
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //if there is a collision
    {
        if (collision.gameObject.layer == 6) //if on layer 6

            if (left == true)  // if moved left - stop left will be made true
            {
                stopL = true;
            }
            if (right == true)
            {
                stopR = true;
            }
    }

    void movingCharR()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + Move * Time.fixedDeltaTime, transform.position.y); //changes position
            timeBtwMove = StartBtwMove;  //starts timer
            timer = false; //restarts the timer
            left = false; //what direction they are turning
            right = true;
            stopL = false; //if move away - turn off stop flag
        }
    }
    void movingCharL()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - Move * Time.fixedDeltaTime, transform.position.y);
            timeBtwMove = StartBtwMove;
            timer = false;
            left = true;
            right = false;
            stopR = false;

        }
    }

    public void swordatk()
    {
        


        Debug.Log("function called");
        if ((collider1Scr.inRange == true) && (atkTimer == 0))  //if the user clicks sword button
        {  //from 0 to how many enemies there are
             enemyScr.takeDmg(1); //passes one into function
             Debug.Log("Health is " + enemyScr.health);
             timer = false;

            
        }
    }
}
