using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollect : MonoBehaviour
{
  
    public static int totalDiamonds = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the diamond if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add diamond to counter
            totalDiamonds++;
            //Test: Print total number of diamonds
            Debug.Log("You currently have " + DiamondCollect.totalDiamonds + " Diamonds.");
            //Destroy diamond
            Destroy(gameObject);
        }
    }
}
