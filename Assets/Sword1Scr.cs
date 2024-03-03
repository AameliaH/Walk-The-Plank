using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword1Scr : MonoBehaviour
{
    
    public GameObject swordEnemy;
    public GameObject enemy;
    private Enemy1Scr enemy1Scr;

    // Start is called before the first frame update
    void Start()
    {
        swordEnemy.SetActive(false);
        enemy1Scr = enemy.GetComponent<Enemy1Scr>();
    }

    public void SwordAtk()
    {
        Debug.Log("A");
        swordEnemy.SetActive(true);
        Debug.Log("B");
        transform.position = new Vector2(enemy1Scr.transform.position.x + 0.6f, enemy1Scr.transform.position.y + 0.1f);
        Debug.Log("swordFunc");
        if (swordEnemy != null)
        {
            StartCoroutine(MoveSword());
        }

    }

    IEnumerator MoveSword()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("In sword function");

        transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
        Debug.Log("End of sword function");
        yield return new WaitForSeconds(0.5f);
        swordEnemy.SetActive(false);


    }
}
