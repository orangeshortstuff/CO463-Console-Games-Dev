using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    //Opens Level 1 Scene
    public void OpenLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    //Opens Level 2 Scene
    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    //Exits Application
    public void QuitGame ()
    {
        Application.Quit();
    }
}
