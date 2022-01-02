using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Used when switching scenes in Unity

public class MainMenu : MonoBehaviour
{
public void PlayGame () //We need to make the method public, in order to call it from the button
{
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
}
