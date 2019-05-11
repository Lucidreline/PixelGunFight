using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // for the bullet replenishments
    GameObject bulletSpawner;
    GameObject bulletSpawner2;
    BulletSpawner bulletSpawnerScript;
    BulletSpawner2 bulletSpawnerScript2;
    bool bulletLoop = true;

    [Header("Displaying")]
    [SerializeField] GameObject winnerScreenUI;
    [SerializeField] TextMeshProUGUI displayWinner;

    [SerializeField] GameObject pauseMenu;
    bool isPaused;

    int p1StarCount = 0;
    int p2StarCount = 0;
    [SerializeField] TextMeshProUGUI p1StarText;
    [SerializeField] TextMeshProUGUI p2StarText;

    [Header("Sending Info")]
    [SerializeField] int bulletReplenishTime = 8;
    [SerializeField] float playerHealth = 100f;
    [SerializeField] float playerMovementSpeed = 7.5f;
    [SerializeField] float playerBulletDamage = 20f;
    [SerializeField] float playerBulletSpeed = 20f;
    [SerializeField] int startAmmoCount = 2;



    //send info
    public float GetPlayerHealth()
    {
        return playerHealth;
    }
    public float GetMovementSpeed()
    {
        return playerMovementSpeed;
    }
    public float GetBulletDamage()
    {
        return playerBulletDamage;
    }
    public float GetBulletSpeed()
    {
        return playerBulletSpeed;
    }
    public int GetStartBulletCount()
    {
        return startAmmoCount;
    }



    void Start()
    {
        bulletSpawner = GameObject.FindGameObjectWithTag("Gun1");
        bulletSpawner2 = GameObject.FindGameObjectWithTag("Gun2");
        bulletSpawnerScript = bulletSpawner.GetComponent<BulletSpawner>();
        bulletSpawnerScript2 = bulletSpawner2.GetComponent<BulletSpawner2>();

        isPaused = false;
        UnpauseGame();
    }

    void Update()
    {
        HandlePauseBtn();
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

    void HandlePauseBtn()
    {
        if (Input.GetKeyDown("space") && isPaused == false)
            PauseGame();

        else if (Input.GetKeyDown("space") && isPaused == true)
            UnpauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void buttonTest()
    {
        Debug.Log("Star Test");
    }

    public void StarDestroyed(int playerNum)
    {
        if(playerNum == 1)
            p1StarCount++;

        else if (playerNum == 2)
            p2StarCount++;

        ManageStars();
    }

    private void ManageStars()
    {
        p1StarText.text = p1StarCount.ToString();
        p2StarText.text = p2StarCount.ToString();

        if (p1StarCount >= 3)
            WinnerScreen(1);

        else if (p2StarCount >= 3)
            WinnerScreen(2);
    }

    private void WinnerScreen(int playerNum)
    {
        Time.timeScale = 0f;
        string winner;

        if(playerNum == 1)
            winner = "Player 1";

        else
            winner = "Player 2";

        displayWinner.text = winner;
        winnerScreenUI.SetActive(true);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
