using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowEnemyScr : MonoBehaviour
{
    public GameObject bow;
    public GameObject enemy1;
    public GameObject meep;
    public Enemy1Scr enemy1Scr;
    public MeepScr meepScr;
    void Start()
    {
        bow.SetActive(false);
        meepScr = meep.GetComponent<MeepScr>();
        enemy1Scr = enemy1.GetComponent<Enemy1Scr>();
    }

    public void BowAtk()
    {
        bow.SetActive(true); //bow appears
        transform.position = new Vector2(enemy1Scr.transform.position.x + 0.63f, meepScr.transform.position.y - 0.25f);
        StartCoroutine(Bow());
    }

    IEnumerator Bow()
    {
        float randValue = Random.value;
        if (randValue < 0.40)
        {
            yield return new WaitForSeconds(1);
            bow.SetActive(false); //bow disappears
            Debug.Log("low bow damage");
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            meepScr.TakeDmg(1); //enemy takes damage
            yield return new WaitForSeconds(1);
            bow.SetActive(false); //bow disappears
        }
    }
}
