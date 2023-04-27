using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 2.0f;
    Vector2 direction;
    Vector2 dmov;
    float dt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            direction = Vector2.down;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            direction = Vector2.right;
        }

        Vector2 position = rb.position;
        dt = Time.fixedDeltaTime;
        dmov = direction * speed * dt;
        rb.position = (position + dmov);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "wall") {
            Vector2 back = (direction * speed * -0.04f);
            rb.position = (rb.position + back);
            direction = Vector2.zero;
        }
    }
}
