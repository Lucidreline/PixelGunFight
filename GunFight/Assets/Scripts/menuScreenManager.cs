using System.Collections.Generic;
using UnityEngine;

public class menuScreenManager : MonoBehaviour
{
    int currentIndex;
    [SerializeField] List<GameObject> menuScreens;
    [Header("Send Info")]
    [SerializeField] int coinShredderBounceLimmit = 3;

    void Start()
    {
        currentIndex = 0;
        SwitchMenuScreen(0);
    }
    
    public int getMenuCoinShredderBounceLimmit() {
        return coinShredderBounceLimmit;
    }
    public void SwitchMenuScreen(int indexNum)
    {
        //This will shut down all menu screens and only
        //enable the one that I want
        currentIndex = indexNum;
        SwitchOffAllMenuScreens();
        menuScreens[indexNum].SetActive(true);
    }

    public void SwitchToNextMenuScreen()
    {
        currentIndex++;
        SwitchOffAllMenuScreens();
        menuScreens[currentIndex].SetActive(true);
    }
    public void SwitchToNextPreviousScreen()
    {
        currentIndex--;
        SwitchOffAllMenuScreens();
        menuScreens[currentIndex].SetActive(true);
    }

    void SwitchOffAllMenuScreens()
    {
        foreach(GameObject menuScreen in menuScreens)
        {
            menuScreen.SetActive(false);
        }
    }

    

}
