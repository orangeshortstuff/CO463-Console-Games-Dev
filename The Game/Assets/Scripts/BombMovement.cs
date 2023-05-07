using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    float timeMoved;
    private float speed = 4f;
    Vector2 dmov;
    float dt;
    Vector2 direction;
    bool hit = false;
    float timeToExplode = 0.5f;
    float timeOut;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D box;

    void Awake()
    {
        float angle = transform.parent.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction.x = Mathf.Sin(angle);
        direction.y = Mathf.Cos(angle) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;
        timeOut += dt;
        dmov = direction * speed * dt;
        rb.position = (rb.position + dmov);
        if (hit)
        {
            timeToExplode -= dt;
            if (timeToExplode <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // figure out a way to make the explosion animation play
        if (other.tag != "coin" && other.tag != "baddie" && other.tag != "node" && timeOut > 0.2f)
        {
            hit = true;
            direction = Vector2.zero;
        }

    }
}
