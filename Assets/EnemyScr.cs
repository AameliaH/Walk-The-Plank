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
    public int damage;
    public float wait;

    public GameObject[] Hp;

    public void Awake()
    {
        meepScr = Meep.GetComponent<MeepScr>();
        enemy1Scr = Enemy1.GetComponent<Enemy1Scr>();
        sword1Scr = enemySword.GetComponent<Sword1Scr>();
        for (int i = 0; i < Hp.Length-1; i++)
        {
            Hp[i].gameObject.SetActive(false);
        }
    }

    public void Start()
    {
        RandomNum = Random.Range(0, 3);
        Debug.Log("num generates" + RandomNum);
    }
    public void TakeDmg(int dmg)
    {
        damage = dmg;
        Enhealth -= dmg;
        Debug.Log("damage TAKEN.Health: " + Enhealth);
        StartCoroutine(Health());
        if (Enhealth == 0)
        {
            StartCoroutine(Win());
        }
    }

    public void EnemyAtk()
    {
        wait = 2;
        if (enemySword != null)
        {
            StartCoroutine(Wait());
            sword1Scr.SwordAtk();
            meepScr.dodge = true; //will dodge in the next turn
        }
        StartCoroutine (AllowMeep());
    }

    public void EnemyMove()
    {
        wait = 0.5f;
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
        wait = 0.5f;
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
        yield return new WaitForSeconds(wait);
        meepScr.timeBtwMove = 0;
        meepScr.swordActive = false;
        yield return new WaitForSeconds(1);
    }

    IEnumerator Health()
    {
        Hp[Enhealth + damage-1].SetActive(false);
        Hp[Enhealth-1].SetActive(true);
        yield return Enhealth;
    }
}
