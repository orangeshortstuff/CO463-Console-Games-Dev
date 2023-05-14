﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D box;
    private float speed = 1.8f;
    Vector2 direction;
    Vector2 dmov;
    private float raycastCooldown = 0.3f;
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
        raycastCooldown -= dt;
        dmov = direction * speed * dt;
        rb.position = (position + dmov);
        if (Mathf.Abs(rb.position.x - Mathf.Round(rb.position.x)) < 0.2f &&
            Mathf.Abs(rb.position.y - Mathf.Round(rb.position.y)) < 0.2f &&
            raycastCooldown < 0)
        {
            GetValidDirections();
        }
    }

    // GetValidDirections casts rays to all four cardinal directions, looking for a node.
    // This is then used to select the node nearest to the player.
    private void GetValidDirections()
    {
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
            Debug.Log(hit_points[i]);
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
            raycastCooldown = 0.3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Vector2 back = (direction * speed * -0.04f);
            rb.position = (rb.position + back);
            GetValidDirections();
        }
    }
}
