using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 2.0f;
    Vector2 position;
    Vector2 direction;
    Vector2 dmov;
    float dt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D> ();
        position = rb.position;
    }

    // ChangeDirectionIfFree is used to check if a player's move would hit a wall
    void ChangeDirectionIfFree(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(position + (dir * 0.3f), dir, 0.4f, Physics2D.DefaultRaycastLayers, 0.25f);
        if (hit.collider == null)
        {
            direction = dir;
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = rb.position;
        if (Input.GetKeyDown(KeyCode.W)) {
            ChangeDirectionIfFree(Vector2.up);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            ChangeDirectionIfFree(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            ChangeDirectionIfFree(Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            ChangeDirectionIfFree(Vector2.right);
        }

        dt = Time.deltaTime;
        dmov = direction * speed * dt;
        rb.position = (position + dmov);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "wall") 
        {
            Vector2 back = (direction * speed * Time.deltaTime * -2.0f);
            rb.position = (rb.position + back);
            direction = Vector2.zero;
        }

        if (other.gameObject.tag == "baddie")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
