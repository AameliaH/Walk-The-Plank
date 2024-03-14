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
        bow.SetActive(true);
        transform.position = new Vector2 (meepScr.transform.position.x + 0.6f, meepScr.transform.position.y + 0.1f);
        enemyScr.TakeDmg(2);
    }
}
