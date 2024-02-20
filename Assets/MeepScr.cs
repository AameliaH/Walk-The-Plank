using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MeepScr : MonoBehaviour
{
    #pragma warning disable IDE0044
    private float Move = 93f;  //how far for the sprite to move
    public float timeBtwMove = 0;   // a timer that starts every time a move is made 


    public int atkTimer = 0;

    public GameObject enemyObj;
    public GameObject collideObj;
    public GameObject swordObj;
    public GameObject enemy1Obj;

    private EnemyScr enemyScr;
    public Collider1Scr collider1Scr;  
    public SwordScr swordScr;
    public Enemy1Scr enemy1Scr;

    public Vector2 swordPos;

    public bool left = true;
    public bool right = true;
    public bool stopL = false;
    public bool stopR = false;
    public bool swordActive = false;
    public bool EnemyMovement;

    private void Awake()
    {
        swordScr = swordObj.GetComponent<SwordScr>();
        collider1Scr = collideObj.GetComponent<Collider1Scr>(); //gets the script from object
        enemyScr = enemyObj.GetComponent<EnemyScr>();
        enemy1Scr = enemy1Obj.GetComponent<Enemy1Scr>();
        transform.position = new Vector2(0, 0.75f); //sets position of user
    }

    private void Start()
    {
        Debug.Log("Health is " + enemyScr.Enhealth);
    }

    void Update()
    {
        if ((timeBtwMove == 0) && (stopR == false)) //if timer is done + no stop flag
        {
            MovingCharR();  //calls function
        }
        if ((timeBtwMove == 0) && (stopL == false))
        {
            MovingCharL();
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
        CheckEnemyLocation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopL = false;
        stopR = false;
    }

    public void CheckEnemyLocation()
    {
        if ((transform.position.x > enemy1Scr.transform.position.x) && (stopR = true))
        {
            stopR = false;
        }

        if ((transform.position.x < enemy1Scr.transform.position.x) && (stopL = true))
        {
            stopL = false;
        }
    }

    void MovingCharR()
    {
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + Move * Time.fixedDeltaTime, transform.position.y); //changes position
            timeBtwMove = 1;  //starts timer
            left = false; //what direction they are turning
            right = true;
            stopL = false; //if move away - turn off stop flag
            StartCoroutine(EnemyTurn());
        }
    }
    void MovingCharL()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.position = new Vector2(transform.position.x - Move * Time.fixedDeltaTime, transform.position.y);
            timeBtwMove = 1;
            left = true;
            right = false;
            stopR = false;
            StartCoroutine(EnemyTurn());

        }
    }

    public void swordatk()
    {
        Debug.Log("function called");
        if ((collider1Scr.inRange == true) && (timeBtwMove == 0))  //if the user clicks sword button
        {  //from 0 to how many enemies there are
            Debug.Log("THING");
            swordScr.sword.SetActive(true);
            swordScr.SwordAtk();
            Debug.Log(swordPos);
            enemyScr.takeDmg(1); //passes one into function
            Debug.Log("Health is " + enemyScr.Enhealth);
            StartCoroutine(EnemyTurn());
            timeBtwMove = 1;
            swordActive = true;
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2);
        if ((collider1Scr.inRange == true) && (swordActive==true))
        {
            enemyScr.Dodge();
            Debug.Log(enemyScr.lastMove);
            swordActive = false;
        }
        else if (collider1Scr.inRange == true)
        {
            enemyScr.EnemyAtk();
            Debug.Log(enemyScr.lastMove);
        }
        else
        {
            enemyScr.EnemyMove();
            Debug.Log(enemyScr.lastMove);
        }

    }
}