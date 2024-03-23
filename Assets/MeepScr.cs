using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MeepScr : MonoBehaviour
{
    #pragma warning disable IDE0044
    private float Move = 93f;  //how far for the sprite to move
    public float timeBtwMove = 0;   // a timer that starts every time a move is made 
    public int atkTimer = 0;
    public int health = 5;
    public int damage;
    public int swordUse = 0;
    public int bowUse = 0;
    public int windUse = 0;
    public int turns = 0;

    public GameObject enemyObj;
    public GameObject collideObj;
    public GameObject swordObj;
    public GameObject enemy1Obj;
    public GameObject collide2Obj;
    public GameObject[] Hp;
    public GameObject bowObj;
    public GameObject collide3Obj;

    private EnemyScr enemyScr;
    public Collider1Scr collider1Scr;  
    public SwordScr swordScr;
    public Enemy1Scr enemy1Scr;
    public Collider2Scr collider2Scr;
    public BowScr bowScr;
    public Collider3Scr collider3Scr;

    public Vector2 swordPos;
    public Vector2 Shift;
    public Collider2D collider1;
    public Collider2D collider2;
    public Text turnText;

    public bool left = true;
    public bool right = true;
    public bool stopL = false;
    public bool stopR = false;
    public bool swordActive = false;
    public bool EnemyMovement;
    public bool dodge = false;
    public bool bowActive = false;
    public bool StopCollide;
    public bool border = false;
    public bool windActive;

    private void Awake()
    {
        swordScr = swordObj.GetComponent<SwordScr>();
        collider1Scr = collideObj.GetComponent<Collider1Scr>(); //gets the script from object
        enemyScr = enemyObj.GetComponent<EnemyScr>();
        enemy1Scr = enemy1Obj.GetComponent<Enemy1Scr>();
        collider2Scr = collide2Obj.GetComponent<Collider2Scr>();
        bowScr = bowObj.GetComponent<BowScr>();
        collider3Scr = collide3Obj.GetComponent<Collider3Scr>();
        transform.position = new Vector2(0, 0.75f); //sets initial position
        for (int i = 0; i < Hp.Length - 1; i++)
        {
            Hp[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        Debug.Log("Health is " + enemyScr.Enhealth);
    }

    void Update()
    {
        if ((timeBtwMove == 0) && (stopR == false)) //if timer is done + no stop flag
        {
            MovingCharR();  //calls function to move right
        }
        if ((timeBtwMove == 0) && (stopL == false))
        {
            MovingCharL();
        }
        StartCoroutine(Border());
        AddTurn(turns);
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
        else if (collision.gameObject.layer == 8)
        {
            StopCollide = true;
        }
        CheckEnemyLocation(); 
    }

    private void OnTriggerExit2D(Collider2D collision) //outside of range
    {
        stopL = false;
        stopR = false;
    }

    public void CheckEnemyLocation() //checks enemy location 
    {
        if ((transform.position.x > enemy1Scr.transform.position.x) && (stopR == true))
        {
            stopR = false;
        }

        if ((transform.position.x < enemy1Scr.transform.position.x) && (stopL == true))
        {
            stopL = false;
        }
    }

    void MovingCharR()
    {
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.position = new Vector2(transform.position.x + Move * Time.fixedDeltaTime, transform.position.y); //changes position
            collide2Obj.transform.position = transform.position;
            timeBtwMove = 1;  //starts timer
            left = false; //what direction they are turning
            right = true;
            stopL = false; //if move away - turn off stop flag
            turns += 1;
            StartCoroutine(EnemyTurn());  //leads to enemy action
        }
    }
    void MovingCharL()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.position = new Vector2(transform.position.x - Move * Time.fixedDeltaTime, transform.position.y);
            collide2Obj.transform.position = transform.position;
            timeBtwMove = 1;
            left = true;
            right = false;
            stopR = false;
            turns += 1;
            StartCoroutine(EnemyTurn());
        }
    }

    public void swordatk()
    {
        Debug.Log("sword called");
        if ((collider1Scr.inRange == true) && (timeBtwMove == 0))  //if the user clicks sword button
        {  
            swordScr.sword.SetActive(true);
            swordScr.SwordAtk();
            Debug.Log(swordPos);
            Debug.Log("Health is " + enemyScr.Enhealth);
            StartCoroutine(EnemyTurn());
            timeBtwMove = 1;
            swordActive = true;
            turns += 1;
            swordUse += 1;
        }
    }

    public void BowAtk()
    {
        Debug.Log("bow called");
        if ((collider2Scr.inRange == true) && (timeBtwMove == 0))
        {
            bowScr.bow.SetActive(true);
            bowScr.BowAtk();
            Debug.Log("Health is " + enemyScr.Enhealth);
            StartCoroutine(EnemyTurn());
            timeBtwMove = 1;
            bowActive = true;
            turns += 1;
            bowUse += 1;
        }
    }

    public void WindAtk()
    {
        Debug.Log("Wind called");
        enemy1Scr.transform.position = new Vector2(transform.position.x - 7.44f, enemy1Scr.transform.position.y); //shifts the enemy
        StartCoroutine (EnemyTurn());
        timeBtwMove = 1;
        turns += 1;
        windUse += 1;
    }

    IEnumerator Border()
    {
        yield return new WaitForSeconds(0.01f);
        if (transform.position.x > 7.44)
        {
            stopR = true;
        }
        else if (transform.position.x < -7.44)
        {
            stopL = true;
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2);







        yield return new WaitForSeconds(2); //waits 2 seconds
        if (((collider1Scr.inRange == true) && (swordActive==true)) || (dodge == true))
        {
            enemyScr.Dodge();   //if enemy has been attacked then it will move away
            Debug.Log(enemyScr.lastMove);
            swordActive = false;
            dodge = false;
        }
        else if (collider1Scr.inRange == true)
        {
            enemyScr.EnemySword();  //if in range enemy can attack user
            Debug.Log(enemyScr.lastMove);
        }
        else
        {
            enemyScr.EnemyMove(); //else it will attempt to move towards the user
            Debug.Log(enemyScr.lastMove);
            StartCoroutine(Wait());
        }
        enemyScr.EnemyBow();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    public void TakeDmg(int dmg)
    {
        damage = dmg;
        health -= dmg; 
        Debug.Log("damage TAKEN.Health: " + health);
        StartCoroutine(Health()); //to change display of health
        if (health <= 0 )
        {
            StartCoroutine(Lose());
        }
    }
    IEnumerator Health()
    {
        Hp[health + damage - 1].SetActive(false);
        Hp[health - 1].SetActive(true);
        yield return health;
    }

    IEnumerator Lose()
    {
        SceneManager.LoadScene("Game Screen"); //switch screens
        yield return new WaitForSeconds(1);
    }

    public void AddTurn(int turn)
    {
        turnText.text = turn.ToString();
    }
}
