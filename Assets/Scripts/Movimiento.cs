using UnityEngine;
public class Movimiento : MonoBehaviour
{
    [SerializeField] private float horizontal;
    private float horizontalRaw;
    [SerializeField] private float horizontalp;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 7.5f;
    [SerializeField] private float fuerzaSalto = 10f;
    [SerializeField] private float fuerzaSalto2 = 10f;
    private Rigidbody2D rb;
    private float previousVelocity;
    private bool Jumping;
    private bool walking;
    //private bool isFalling;
    private bool animJump = false;


    [SerializeField] private SFX sfx;
    [SerializeField] SpriteRenderer playerRenderer;
    public Camera mainCamera;




    public float jumpTime = 0.5f;  // Tiempo máximo de salto

    private bool isJumping = false;
    private float jumpTimeCounter;
    private bool running;
    private float velGradual;
    private float tazaDisminucion;
    private float horizontalInv;
    private int lastDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity.y;
        //anim = GetComponent<Animator>();
        _obtenCamara();
        jumpTimeCounter = jumpTime;
    }

    private void _obtenCamara()
    {
        // Ensure the main camera is set
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

    }

    private void FixedUpdate()
    {
        if (IsPlayerTouchingLeft()) return;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    void Update()
    {
        if (IsPlayerTouchingLeft() && horizontal < 0.0f) return; //evitar que el personaje pase de la camara a la izquierda

        //anim.SetBool("Jumping", false);//Codigo animacion salto
        //anim.SetBool("Run", horizontal != 0.0f);//codigo animacion correr
        if (rb.velocity.y <= 0)
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



        horizontal = Input.GetAxis("Horizontal");
        horizontalRaw = Input.GetAxisRaw("Horizontal");
        if (horizontalRaw > 0)
        {
            tazaDisminucion = horizontalRaw - .9f;
        }
        else if (horizontalRaw < 0)
        {
            tazaDisminucion = horizontalRaw + .9f;
        }

        velGradual = horizontalRaw;
        if (velGradual < 0)
        {
            velGradual = velGradual * -1;
        }

        if (horizontalRaw == 0)
        {
            velGradual = Mathf.Lerp(velGradual, 0, 0.01f * Time.deltaTime);
        }


        Debug.Log(velGradual);

        transform.Translate(horizontal * speed * Time.deltaTime * velGradual, 0, 0);//Codigo para moverse

        

        if (horizontal < 0.0f)
        {
            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                WalkingOn();
            }
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontal > 0.0f)
        {
            if(Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                WalkingOn();
            }
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }//Codigo que corrige la orientacion del player
        if (horizontal == 0 || Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            WalkingOff();
        }

        if (Input.GetKeyDown(KeyCode.Z) && Mathf.Abs(rb.velocity.y) < 0.001f && !isJumping)
        {
            //rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            //anim.SetBool("Jumping", true);
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            isJumping = true;
            jumpTimeCounter = jumpTime;

            sfx.PlayJump();
            animJump = true;
        }//Animacion de salto

        if (Input.GetKey(KeyCode.Z) && isJumping)
        {
            
            
                //fuerzaSalto = fuerzaSalto - variableDecaida;
            
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            fuerzaSalto = fuerzaSalto2;
            isJumping = false;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            running = false;
        }
        if (running)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        _checkAnimation();
    }

    private bool IsPlayerTouchingLeft()
    {
        // Get the boundaries of the player's sprite in screen space.
        Vector3 spriteMin = mainCamera.WorldToScreenPoint(playerRenderer.bounds.min);
        Vector3 spriteMax = mainCamera.WorldToScreenPoint(playerRenderer.bounds.max);

        // Get the camera's left boundary in screen space.
        float cameraLeft = 0.0f;

        // Check if the player's sprite is touching the left boundary of the camera.
        return spriteMin.x <= cameraLeft && spriteMax.x >= cameraLeft;
    }

    private void WalkingOn()
    {
        if (walking == false)
        {
            sfx.PlayWalk();
            walking = true;
            if (animJump) return;
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


    void _checkAnimation()
    {
        if (animJump)
        {
            anim.Play("Jump");
            return;
        }
        if (walking)
        {
            anim.Play("Caminando");
            return;
        }

        anim.Play("Parado");

    }
}
