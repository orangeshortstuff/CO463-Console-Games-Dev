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
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D box;

    void Awake()
    {
        float angle = transform.parent.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction.x = Mathf.Sin(angle);
        direction.y = Mathf.Cos(angle) * -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dt = Time.fixedDeltaTime;
        dmov = direction * speed * dt;
        rb.position = (rb.position + dmov);
    }
}
