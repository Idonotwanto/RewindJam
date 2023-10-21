using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5.0f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isWalking;
    
    private void Start()
    {
        currentSpeed = baseSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * currentSpeed, rb.velocity.y);

        isWalking = Mathf.Abs(horizontalInput) > 0.01f;
        UpdateAnimation();
    }

   void UpdateAnimation()
    {
        if (isWalking)
        {
            anim.SetTrigger("Caminando");
        }
        else
        {
            anim.SetTrigger("Parado");
        }
    }

    public void IncreaseSpeed(float multiplier)
    {
        currentSpeed *= multiplier;
    }

    public void ResetSpeed()
    {
        currentSpeed = baseSpeed;
    }
}
