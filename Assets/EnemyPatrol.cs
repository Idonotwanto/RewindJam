using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform currentPoint;
    public float speedOg;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = -speedOg;

    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collider)
    { 
        if (collider.gameObject.tag == "Wall")
        {
            Debug.Log("Wall"+speed);
            speed = -speed;
            Debug.Log(speed);
        }
        if (collider.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
