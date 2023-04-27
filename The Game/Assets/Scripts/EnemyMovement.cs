using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 2.0f;
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
        if (Mathf.Abs(rb.position.x - Mathf.Round(rb.position.x)) < 0.05f ||
            Mathf.Abs(rb.position.y - Mathf.Round(rb.position.y)) < 0.05f)
        {
            GetValidDirections();
        }
    }

    // GetValidDirections casts rays to all four cardinal directions, looking for a node.
    // This is then used to select the node nearest to the player.
    private void GetValidDirections()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Vector2 back = (direction * speed * -0.04f);
            rb.position = (rb.position + back);
            GameObject player = GameObject.Find("Player");
            float distx = (player.transform.position.x - rb.position.x);
            float disty = (player.transform.position.y - rb.position.y);
            if (Mathf.Abs(distx) < Mathf.Abs(disty)) {
                direction.x = Mathf.RoundToInt(Mathf.Sign(distx));
                direction.y = 0;
            } else {
                direction.y = Mathf.RoundToInt(Mathf.Sign(disty));
                direction.x = 0;
            }
            if (Random.Range(0,10) == 0) {
                direction = directionList[Random.Range(0,4)];
            }
        }
    }
}
