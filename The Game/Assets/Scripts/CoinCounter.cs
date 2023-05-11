using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text counterText;

    // Start is called before first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
        counterText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //The current number of coins to display
        if (counterText.text != PlayerMovement.totalCoins.ToString())
        {
            counterText.text = PlayerMovement.totalCoins.ToString();
        }
    }
}
