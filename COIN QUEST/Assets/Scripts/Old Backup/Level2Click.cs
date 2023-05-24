using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level2Click : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (this.name == "Level2")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}

