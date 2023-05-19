using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level1Click : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (this.name == "Level1")
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}

