using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    float timeSinceLastThrow;
    public GameObject myPrefab;
    Vector2 direction;
    bool willThrow = false;

    private void Awake()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle) * -1); // angle for the raycast (down at z = 0)
    }

    // FixedUpdate is called 50 times / second
    void FixedUpdate()
    {
        timeSinceLastThrow += Time.fixedDeltaTime;
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position + (direction * 0.5f), direction, Mathf.Infinity, Physics2D.DefaultRaycastLayers, 0.15f);
        // if the cast ray hit the player, and it's not on cooldown, charge a bomb throw
        if (timeSinceLastThrow > 2 && hit.transform.CompareTag("Player")) 
        {
            timeSinceLastThrow = 0;
            willThrow = true;
        }

        if (willThrow && timeSinceLastThrow > 0.5f) 
        {
            Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            timeSinceLastThrow = 0;
            willThrow = false;
        }

        if (PlayerManager.isGameOver)
        {
            gameObject.SetActive(false);
        }
    }
}
