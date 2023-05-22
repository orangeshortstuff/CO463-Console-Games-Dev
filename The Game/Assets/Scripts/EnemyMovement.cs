using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D box;
    private float speed = 1.8f;
    Vector2 direction;
    Vector2 dmov;
    float dt;
    float raycastCooldown = 0f;
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
        raycastCooldown -= dt;
        dmov = direction * speed * dt;
        rb.position = (position + dmov);
        if (Mathf.Abs(position.x - Mathf.Round(position.x)) < 0.12f &&
        Mathf.Abs(position.y - Mathf.Round(position.y)) < 0.12f &&
        raycastCooldown < 0)
        {
            GetValidDirections();
        }

        if (PlayerManager.isGameOver)
        {
            gameObject.SetActive(false);
        }
    }

    // GetValidDirections casts rays to all four cardinal directions, looking for nodes.
    // It then selects the node closest to the player, and moves towards that node.
    private void GetValidDirections()
    {
        raycastCooldown = 0.2f;
        Collider2D [] colliders = new Collider2D [directionList.Length];
        Vector2 [] hit_points = new Vector2 [directionList.Length];
        string [] tags = new string [directionList.Length];
        int i = 0;
        foreach (Vector2 dir in directionList)
        {
            Vector2 offset = dir * 0.33f;
            // cast a ray in each direction, only returning results with a z position above 0 (to prevent coins from being hit)
            RaycastHit2D hit = Physics2D.Raycast(rb.position + offset, dir, Mathf.Infinity, Physics2D.DefaultRaycastLayers, 0);
            colliders[i] = hit.collider;
            hit_points[i] = hit.point;
            tags[i] = hit.collider.tag;
            // Debug.Log(tags[i]);
            i++;
        }

        //  check if one of the rays hit the player - if it did, move in that direction 
        int castHitPlayer = System.Array.IndexOf(tags, "Player");
        if (castHitPlayer >= 0)
        {
            direction = directionList[castHitPlayer];
        }
        else
        {
            Vector2 playerPos = GameObject.FindWithTag("Player").transform.position;
            List<float> mags = new List<float>();
            // calculate the distance between the player and any hit nodes
            for (i = 0; i < tags.Length; i++)
            {
                if (tags[i] == "node")
                {
                    mags.Add((hit_points[i] - playerPos).magnitude);
                }
                else
                {
                    mags.Add(Mathf.Infinity);
                }
            }

            // find the lowest distance, get that index, and turn it to a direction, so the enemy points that way
            direction = directionList[mags.IndexOf(Mathf.Min(mags.ToArray()))];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Vector2 back = (direction * speed * -0.04f);
            rb.position = (rb.position + back);
            Vector2 correction;
            if (Mathf.Abs(rb.position.x - Mathf.Round(rb.position.x)) > 0.12f)
            {
                correction.x = (rb.position.x + Mathf.Round(rb.position.x)) / 2;
            } 
            else
            {
                correction.x = rb.position.x;
            }

            if (Mathf.Abs(rb.position.y - Mathf.Round(rb.position.y)) > 0.12f)
            {
                correction.y = (rb.position.y + Mathf.Round(rb.position.y)) / 2;
            }
            else 
            {
                correction.y = rb.position.y;
            }

            rb.position = correction;
            GetValidDirections();
        }
    }
}
