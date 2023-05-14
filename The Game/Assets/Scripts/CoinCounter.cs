using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text counterText;

    // Start is called before first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
        CoinCollection.totalCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //The current number of coins to display
        if (counterText.text != CoinCollection.totalCoins.ToString())
        {
            counterText.text = CoinCollection.totalCoins.ToString();
        }
    }
}
