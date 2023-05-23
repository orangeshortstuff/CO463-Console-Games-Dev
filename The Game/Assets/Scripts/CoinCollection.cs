using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    //Counts the total amount of coins picked up 
    public static int totalCoins = 0;

    void Awake()
    {
        //Make Collider2D a trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroys the coin if the Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            SoundManager.instance.coinssource.PlayOneShot(SoundManager.instance.coinSound);
            // Add coin to counter
            totalCoins++;

            // Destroy coin
            Destroy(gameObject);
        }
    }
}
