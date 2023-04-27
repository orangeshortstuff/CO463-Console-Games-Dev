using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 3.0f;
    Vector2 direction;
    Vector2 dmov;
    float dt;
    Vector2[] directionList = new Vector2[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right};

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        direction = directionList[Random.Range(0,4)];
    }

    // FixedUpdate is called 50 times a second, so the framerate doesn't matter for collisions
    void FixedUpdate()
    {
        Vector2 position = rb.position;
        dt = Time.fixedDeltaTime;
        dmov = direction * speed * dt;
        rb.position = (position + dmov);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Vector2 back = (direction * speed * -0.04f);
            rb.position = (rb.position + back);
            GameObject player = GameObject.Find("Player");
            float distx = (rb.position.x - player.transform.position.x);
            Debug.Log(distx / Mathf.Abs(distx));
            float disty = (rb.position.y - player.transform.position.y);
            Debug.Log(disty / Mathf.Abs(disty));
            direction = directionList[Random.Range(0,4)];
        }
    }
}
