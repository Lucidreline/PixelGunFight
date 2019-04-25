using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int p1StarCount = 0;
    //int p2StarCount = 0;
    [SerializeField]TextMeshProUGUI p1StarText;
    //[SerializeField]TextMeshProUGUI p2StarText;

    // for the bullet replenishments
    GameObject bulletSpawner;
    //GameObject bulletSpawner2;
    BulletSpawner bulletSpawnerScript;
    //BulletSpawner bulletSpawnerScript2;
    [SerializeField] int bulletReplenishTime = 8;
    bool bulletLoop = true;

    void Start()
    {
        bulletSpawner = GameObject.FindGameObjectWithTag("Gun1");
        //bulletSpawner2 = GameObject.FindGameObjectWithTag("Gun2");
        bulletSpawnerScript = bulletSpawner.GetComponent<BulletSpawner>();
        //bulletSpawnerScript = bulletSpawner2.GetComponent<BulletSpawner>();

    }

    void Update()
    {
        if (bulletLoop)
        {
            StartCoroutine(AddBulletsEveryXSeconds());
        }
    }

    IEnumerator AddBulletsEveryXSeconds()
    {
        bulletLoop = false;
        yield return new WaitForSeconds(bulletReplenishTime);
        bulletLoop = true;
        bulletSpawnerScript.AddAmmo(1);
        //bulletSpawnerScript2.AddAmmo(1);
        

    }

    public void StarDestroyed(int playerNum)
    {
        if(playerNum == 1)
        {
            p1StarCount++;
        }else if (playerNum == 2)
        {
            //p2StarCount++;
        }
        ManageStars();
    }

    private void ManageStars()
    {
        p1StarText.text = p1StarCount.ToString();
        //p2StarText.text = p2StarCount.ToString();

        if (p1StarCount >= 3)
        {
            //p1 wins
            Debug.Log("P1 wins");
        }
        //else if (p2StarCount >= 3)
        //{
            //p1 wins
            //Debug.Log("P2 wins");
        //}
    }
}
