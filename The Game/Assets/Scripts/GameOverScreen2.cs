using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen2 : MonoBehaviour
{  
    //Opens Level 2 Scene
    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    //Opens Main Menu
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
