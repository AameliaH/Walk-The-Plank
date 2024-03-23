using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScr : MonoBehaviour
{
    public GameObject bow;
    public GameObject enemy;
    public GameObject meep;
    public EnemyScr enemyScr;
    public MeepScr meepScr;
    void Start()
    {
        bow.SetActive(false);
        meepScr = meep.GetComponent<MeepScr>();
        enemyScr = enemy.GetComponent<EnemyScr>();  
    }

    public void BowAtk()
    {
        bow.SetActive(true); //bow appears
        transform.position = new Vector2 (meepScr.transform.position.x - 0.7f, meepScr.transform.position.y - 0.25f);
        StartCoroutine(Bow());
    }

    IEnumerator Bow()
    {
        float randValue = Random.value;
        if (randValue < 0.40)
        {
            yield return new WaitForSeconds(1);
            bow.SetActive(false); //bow disappears
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            enemyScr.TakeDmg(1); //enemy takes damage
            yield return new WaitForSeconds(1);
            bow.SetActive(false); //bow disappears
        }
    }
}
