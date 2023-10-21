using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float horizontalp;
    //[SerializeField] private Animator anim;
    [SerializeField] private float speed = 3;
    private float fuerzaSalto = 5f;
    private Rigidbody2D rb;
    private float previousVelocity;
    private bool Jumping;
    private bool walking;
    private bool Bug = false;
    private bool BugT = false;
    private bool BugPI = false;
    //private bool isFalling;
    private bool animJump = false;

    //[SerializeField] private Joystick JS;

    [SerializeField] private SFX sfx;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity.y;
        //anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    void Update()
    {
        if (Bug)
        {
            transform.Translate(Vector3.up * .15f);
        }
        if (BugT)
        {
            transform.Translate(Vector3.down * .15f);
        }
        if (BugPI)
        {
            transform.Translate(Vector3.right * .15f);
        }//codigo para desbugearse



        if (rb.velocity.y < 0)
        {
            //isFalling = true;
            //anim.SetBool("Cayendo", true);
            animJump = false;
        }
        else
        {
            //isFalling = false;
            //anim.SetBool("Cayendo", false);
        } //Codigo animacion salto



                horizontal = Input.GetAxisRaw("Horizontal");
        //anim.SetBool("Jumping", false);//Codigo animacion salto
        //anim.SetBool("Run", horizontal != 0.0f);//codigo animacion correr

        //horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);//Codigo para moverse

        if (horizontal < 0.0f)
        {
            WalkingOn();
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            WalkingOn();
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }//Codigo que corrige la orientacion del player
        if (horizontal == 0)
        {
            WalkingOff();
        }

        if (animJump)
        {
            //anim.SetBool("Jumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            //anim.SetBool("Jumping", true);
            sfx.PlayJump();
        }//Animacion de salto
    }
    private void WalkingOn()
    {
        if (walking == false)
        {
            sfx.PlayWalk();
            walking = true;
        }
    }
    private void WalkingOff()
    {
        if (walking == true)
        {
            sfx.StopWalk();
            walking = false;
        }
    }
    public void BotonJump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            animJump = true;
            sfx.PlayJump();
        }
    }
}
