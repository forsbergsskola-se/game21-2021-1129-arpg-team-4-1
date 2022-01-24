using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Used when switching scenes in Unity

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LevelLoader LL;

    public void PlayGame () //We need to make the method public, in order to call it from the button
    {
       LL.LoadNextLevel();
    }

    public void QuitGame () //This will close down the program when pressing the "Quit"-button in Main Menu
    {
        Debug.Log ("QUIT!"); //Unity Editor will not close the program, instead this message will let us know that this is working
        Application.Quit();
    }
}