using UnityEngine;

//It is in charge of switching between screens and sending events when the computer buttons are pressed.
public class ComputerUIManager : MonoBehaviour
{
    [SerializeField] Screen[] screens; //stores all different screens on the computer.

    [Tooltip("starting index")]
    [SerializeField] int currentIndex = 0; //starting scree

    public Screen activeScreen;
    public Screen ActiveScreen { get { return activeScreen; } }

    void Awake()
    {
        if (IsArrayEmpty()) screens = GetComponentsInChildren<Screen>();
        activeScreen = screens[currentIndex];
    }
    private bool IsArrayEmpty()
    {
        //todo
        return false;
    }
    

    //called on a button OnClick event.
    public void ChangeScreens()
    {
        activeScreen.gameObject.SetActive(false);


        currentIndex++;
        if (currentIndex > screens.Length - 1) currentIndex = 0; //starts the index count again after the index reaches the last element of the array.
        activeScreen = screens[currentIndex]; //sets the new active screen

        activeScreen.gameObject.SetActive(true);
    }

    //called on a button OnClick event.
    public void HandleUpBottonPress()
    {
        activeScreen.HandleUpButtonPress();
    }

    public void HandleDownBottonPress()
    {
        activeScreen.HandleDownButtonPress();
    }
}
