using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScreenManager : MonoBehaviour
{
    int currentIndex;
    [SerializeField] List<GameObject> menuScreens;
    //menu screen index list
    //0 = mainMenu
    //1 = Game Modes
    //2 = Controls

    void Start()
    {
        currentIndex = 0;
        SwitchMenuScreen(0);
    }
    
    public void SwitchMenuScreen(int indexNum)
    {
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
