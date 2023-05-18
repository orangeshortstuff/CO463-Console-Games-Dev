using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MouseClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (this.name == "PlayButton")
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}

