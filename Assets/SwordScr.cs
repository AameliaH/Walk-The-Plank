using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordScr : MonoBehaviour
{
    public GameObject sword;
    public GameObject meep;
    private MeepScr meepScr;
    public GameObject enemy;
    public EnemyScr enemyScr;

    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false); //sword only appears when used
        meepScr = meep.GetComponent<MeepScr>();
        enemyScr = enemy.GetComponent<EnemyScr>();
    }

    public void SwordAtk()
    {
        sword.SetActive(true);
        transform.position = new Vector2(meepScr.transform.position.x - 0.71f, meepScr.transform.position.y); //shifts sword to where the enemy is
        Debug.Log("swordFunc");
        if (sword != null )
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
            transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
            enemyScr.TakeDmg(3);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
            yield return new WaitForSeconds(0.5f);
            sword.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(1); //moves sword to attack before disappearing
            transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
            enemyScr.TakeDmg(2);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
            yield return new WaitForSeconds(0.5f);
            sword.SetActive(false);
        }
    }
}
