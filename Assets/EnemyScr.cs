using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScr : MonoBehaviour
{
    public int Enhealth = 5;
    public GameObject Meep;
    public GameObject Enemy1;
    public Enemy1Scr enemy1Scr;
    public MeepScr meepScr;
    private bool death = false;
    public string lastMove = "Empty";
    public int RandomNum;
    public GameObject enemySword;
    public Sword1Scr sword1Scr;


    public void Awake()
    {
        meepScr = Meep.GetComponent<MeepScr>();
        enemy1Scr = Enemy1.GetComponent<Enemy1Scr>();
        sword1Scr = enemySword.GetComponent<Sword1Scr>();
    }

    public void Start()
    {
        RandomNum = Random.Range(0, 3);
        Debug.Log("num generates" + RandomNum);
    }
    public void takeDmg(int dmg)
    {
        Enhealth -= dmg;
        Debug.Log("damage TAKEN");
        if (Enhealth == 0)
        {
            StartCoroutine(Win());
        }
    }

    public void EnemyAtk()
    {
        meepScr.timeBtwMove = 0; //allows user to move 
        lastMove = "Attack";
        meepScr.swordActive = false;
        StartCoroutine(Wait()); 
        sword1Scr.SwordAtk();
        meepScr.dodge = true; //will dodge in the next turn
    }

    public void EnemyMove()
    {
        Debug.Log("Move");
        if (meepScr.transform.position.x > enemy1Scr.transform.position.x) //If the user is to the right of the enemy
        {
            StartCoroutine(Wait()); 
            enemy1Scr.MovingEnemyR(); //move right towards the user
        }
        else
        {
            StartCoroutine(Wait());
            enemy1Scr.MovingEnemyL();
        }
        StartCoroutine(AllowMeep()); 
    }

    public void Dodge()
    {
        Debug.Log("Dodge");
        if (meepScr.transform.position.x > enemy1Scr.transform.position.x)
        {
            StartCoroutine(Wait());
            enemy1Scr.MovingEnemyL();
            Debug.Log("Left");

        }
        else
        {
            StartCoroutine(Wait());
            enemy1Scr.MovingEnemyL();
            Debug.Log("Right");
        }

        StartCoroutine(AllowMeep());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        meepScr.stopL = true;
        meepScr.stopR = true;

    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu Screen");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator AllowMeep() //allows the user to move 
    {
        yield return new WaitForSeconds(1);
        meepScr.timeBtwMove = 0;
        lastMove = "Dodge";
        meepScr.swordActive = false;
        yield return new WaitForSeconds(1);
    }
}
