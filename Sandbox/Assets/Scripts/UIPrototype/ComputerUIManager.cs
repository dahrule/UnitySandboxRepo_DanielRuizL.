using UnityEngine;
using System;

//Class in charge of managing screens and executing routines related to the different computer functionalities.
public class ComputerUIManager : MonoBehaviour
{
    [SerializeField] Screen[] screens; //stores all different screens available on the computer.

    [Tooltip("First screen shown")]
    [SerializeField] Screen startingScreen;

    Screen activeScreen;
    int screenIndex; 
    
    public Screen ActiveScreen { get { return activeScreen; } }

    void Awake()
    {
        //Fill if array is empty.
        if (IsArrayEmpty()) screens = GetComponentsInChildren<Screen>();

        foreach(Screen screen in screens)
        {
            screen.gameObject.SetActive(false);
        }
        activeScreen = startingScreen;
        screenIndex = Array.IndexOf(screens,activeScreen);
        activeScreen.gameObject.SetActive(true);
    }

    private bool IsArrayEmpty()
    {
        //TODO
        return false;
    }
    

    //Called on the OnClick event of the "MODE" Button.
    public void ChangeScreens()
    {
        activeScreen.gameObject.SetActive(false);//disables current active screen.

        screenIndex++;
        if (screenIndex > screens.Length - 1) screenIndex = 0; //cycles the array.
        activeScreen = screens[screenIndex]; //sets the new active screen

        activeScreen.gameObject.SetActive(true);//enables new active screen.
    }

    //Called on OnClick events of the different buttons.
    public void HandleUpBottonPress()
    {
        activeScreen.HandleUpButtonPress();
    }

    public void HandleDownBottonPress()
    {
        activeScreen.HandleDownButtonPress();
    }

    //Enables routines on the computer related to diving  when a dive starts.
    public void EnterDiveMode()
    {
        //Enables:DepthSensor, NoDecoTimer.
        //Sets computer to diveScreen.
    }
}
