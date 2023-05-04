﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    float timeSinceLastThrow;
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastThrow += Time.fixedDeltaTime;
        if (timeSinceLastThrow > 1)
        {
            Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            timeSinceLastThrow = 0;
        }
    }
}