using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    float timeSinceLastThrow;
    public GameObject myPrefab;
    Vector2 boxSize = new Vector2(5,5);
    float throwAngle;
    Vector2 throwDirection;

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastThrow += Time.fixedDeltaTime;
        if (timeSinceLastThrow > 2)
        {
            Vector2 position = transform.position;
            throwAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            throwDirection = new Vector2(Mathf.Sin(throwAngle), (Mathf.Cos(throwAngle) * -1));
            RaycastHit2D hit = Physics2D.Raycast(position + (throwDirection * 0.5f), throwDirection, Mathf.Infinity, Physics2D.DefaultRaycastLayers, 0.01f);
            Debug.Log(position + (throwDirection * 0.5f));
            Debug.Log(hit.collider.name);
            if(hit.collider.tag == "Player")
            {
                throwAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
                throwDirection = new Vector2(Mathf.Sin(throwAngle), (Mathf.Cos(throwAngle) * -1));
                timeSinceLastThrow = 0;
                Instantiate(myPrefab, transform.position, transform.rotation, this.transform);
            }
            
        }
    }
}
