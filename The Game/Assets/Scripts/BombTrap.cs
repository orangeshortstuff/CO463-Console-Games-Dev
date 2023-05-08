using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    float timeSinceLastThrow;
    public GameObject myPrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastThrow += Time.fixedDeltaTime;
        if (timeSinceLastThrow > 2)
        {
            Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            timeSinceLastThrow = 0;
        }
    }
}
