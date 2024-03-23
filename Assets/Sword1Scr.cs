using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1Scr : MonoBehaviour
{
    
    public GameObject swordEnemy;
    public GameObject enemy;
    private Enemy1Scr enemy1Scr;
    public GameObject meep;    
    public MeepScr meepScr;

    void Start()
    {
        swordEnemy.SetActive(false);
        enemy1Scr = enemy.GetComponent<Enemy1Scr>();
        meepScr = meep.GetComponent<MeepScr>();
    }

    public void SwordAtk()
    {
        Debug.Log("swordFunc");
        swordEnemy.SetActive(true); //enemy sword appears
        transform.position = new Vector2(enemy1Scr.transform.position.x + 0.6f, enemy1Scr.transform.position.y + 0.1f);
        if (swordEnemy != null)
        {
            StartCoroutine(MoveSword());
        }

    }

    IEnumerator MoveSword()
    {

        float randValue = Random.value;
        if (randValue < 0.20)
        {
            yield return new WaitForSeconds(1); //moves sword to attack before disappearing
            transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
            meepScr.TakeDmg(3);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
            yield return new WaitForSeconds(0.5f);
            swordEnemy.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(1); //moves sword to attack before disappearing
            transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
            meepScr.TakeDmg(2);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
            yield return new WaitForSeconds(0.5f);
            swordEnemy.SetActive(false);
        }
    }

}
