using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    float timeSinceLastThrow;
    public GameObject myPrefab;
    Vector2 direction;

    private void Awake()
    {
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle) * -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastThrow += Time.fixedDeltaTime;
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position + (direction * 0.5f), direction, Mathf.Infinity, Physics2D.DefaultRaycastLayers, 0.15f);
        if (timeSinceLastThrow > 2 && hit.transform.CompareTag("Player"))
        {
            Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            timeSinceLastThrow = 0;
        }
    }
}
