using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int p1StarCount = 0;
    int p2StarCount = 0;
    [SerializeField]TextMeshProUGUI p1StarText;
    //[SerializeField]TextMeshProUGUI p2StarText;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //p2StarText.text = p2StarCount.ToString();

        if (p1StarCount >= 3)
        {
            //p1 wins
        }
        else if (p2StarCount >= 3)
        {
            //p1 wins
        }

    }

}
