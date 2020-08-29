using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScreensController : MonoBehaviour
{
    [HideInInspector]
    List<GameObject> screens;

    public Image barImage;
    public Text winLoseText;

    public GameObject MainScreen;
    public GameObject GameScreen;
    public GameObject WinLoseScreen;

    public enum Screens
    {
        MainScreen,
        GameScreen,
        WinLoseScreen,
  
    }

    private void Awake()
    {
        screens = new List<GameObject>();
        screens.Add(MainScreen);
        screens.Add(GameScreen);
        screens.Add(WinLoseScreen);
    }

    private void Start()
    {
        SetUpStartedScreen();
    }

    public void SetUpStartedScreen()
    {

        ShowScreen("MainScreen");

    }

    public void ShowScreen(string ScreenName)
    {

        foreach (var item in screens)
        {
            if (item.name == ScreenName)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }

        DoPreShownScreenJobs(ScreenName);
    }


    private void DoPreShownScreenJobs(string ScreenName)
    {

        if (ScreenName == nameof(Screens.MainScreen))
        {

        }


        if (ScreenName == nameof(Screens.GameScreen))
        {
            
        }


        if (ScreenName == nameof(Screens.WinLoseScreen))
        {
  
        }

     
    }
}

