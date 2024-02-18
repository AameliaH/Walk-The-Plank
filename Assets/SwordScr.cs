using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScr : MonoBehaviour
{
    public GameObject sword;
    public GameObject meep;
    private MeepScr meepScr;
    private float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false);
        meepScr = meep.GetComponent<MeepScr>();
    }

    public void swordA()
    {
        transform.position = meepScr.transform.position;
        transform.position = new Vector2(transform.position.x - 0.71f, transform.position.y);
        sword.SetActive(true);
        Debug.Log("swordFunc");
        StartCoroutine(MoveSword());
    }

    IEnumerator MoveSword()
    { 
        yield return new WaitForSeconds(1);
        Debug.Log("In sword function");
        
        transform.position = new Vector2(transform.position.x - 0.50f, transform.position.y);
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector2(transform.position.x + 0.50f, transform.position.y);
        Debug.Log("End of sword function");
        yield return new WaitForSeconds(0.5f);
        sword.SetActive(false);


    }
}
