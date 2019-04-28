using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScreenManager : MonoBehaviour
{
    [SerializeField] List<GameObject> menuScreens;
    //menu screen index list
    //0 = mainMenu
    //1 = Game Modes
    //2 = Controls

    void Start()
    {
        SwitchMenuScreen(0);
    }
    
    public void SwitchMenuScreen(int indexNum)
    {
        SwitchOffAllMenuScreens();
        menuScreens[indexNum].SetActive(true);
    }

    void SwitchOffAllMenuScreens()
    {
        foreach(GameObject menuScreen in menuScreens)
        {
            menuScreen.SetActive(false);
        }
    }

    
    
}
