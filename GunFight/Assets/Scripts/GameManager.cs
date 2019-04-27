using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int p1StarCount = 0;
    int p2StarCount = 0;
    [SerializeField]TextMeshProUGUI p1StarText;
    [SerializeField]TextMeshProUGUI p2StarText;

    // for the bullet replenishments
    GameObject bulletSpawner;
    GameObject bulletSpawner2;
    BulletSpawner bulletSpawnerScript;
    BulletSpawner2 bulletSpawnerScript2;
    [SerializeField] int bulletReplenishTime = 8;
    bool bulletLoop = true;

    [SerializeField] GameObject winnerScreenUI;
    [SerializeField] TextMeshProUGUI displayWinner;

    void Start()
    {
        bulletSpawner = GameObject.FindGameObjectWithTag("Gun1");
        bulletSpawner2 = GameObject.FindGameObjectWithTag("Gun2");
        bulletSpawnerScript = bulletSpawner.GetComponent<BulletSpawner>();
        bulletSpawnerScript2 = bulletSpawner2.GetComponent<BulletSpawner2>();

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
        bulletSpawnerScript2.AddAmmo(1);
        

    }

    public void StarDestroyed(int playerNum)
    {
        if(playerNum == 1)
        {
            p1StarCount++;
        }else if (playerNum == 2)
        {
            p2StarCount++;
        }
        ManageStars();
    }

    private void ManageStars()
    {
        p1StarText.text = p1StarCount.ToString();
        p2StarText.text = p2StarCount.ToString();

        if (p1StarCount >= 3)
        {
            WinnerScreen(1);
            Debug.Log("P1 wins");
        }
        else if (p2StarCount >= 3)
        {
            WinnerScreen(2);
            Debug.Log("P2 wins");
        }
    }

    private void WinnerScreen(int playerNum)
    {
        string winner;

        if(playerNum == 1)
        {
            winner = "Player 1";
        }
        else
        {
            winner = "Player 2";
        }
        displayWinner.text = winner;
        winnerScreenUI.SetActive(true);
    }
}
