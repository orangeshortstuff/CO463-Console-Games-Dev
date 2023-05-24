using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject winText;
    public GameObject loseText;
    public int coinsToCollect;

    private void Awake()
    {
        isGameOver = false;
        coinsToCollect = GameObject.FindGameObjectsWithTag("coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            winText.SetActive(false);
            loseText.SetActive(true);
        }

        // Call a game over if all the coins have been collected
        if (CoinCollection.totalCoins >= coinsToCollect)
        {
            isGameOver = true;
            winText.SetActive(true);
            loseText.SetActive(false);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
