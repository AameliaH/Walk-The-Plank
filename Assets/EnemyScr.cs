using System.Collections;
using System.Collections.Generic;
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


    public void Awake()
    {
        meepScr = Meep.GetComponent<MeepScr>();
        enemy1Scr = Enemy1.GetComponent<Enemy1Scr>();
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
        meepScr.timeBtwMove = 0;
        meepScr.swordActive = true;
        lastMove = "Attack";
    }

    public void EnemyMove()
    {
        if (meepScr.transform.position.x > enemy1Scr.transform.position.x)
        {
            StartCoroutine(Wait());
            enemy1Scr.movingEnemyR();
        }
        else
        {
            StartCoroutine(Wait());
            enemy1Scr.movingEnemyL();
        }
        meepScr.timeBtwMove = 0;
        meepScr.swordActive = true;
        lastMove = "Move";
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu Screen");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
