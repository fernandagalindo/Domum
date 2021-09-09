using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Rigidbody2D Barco;
    private Animator anim;
    private Vector3 playInitialPosition;

    [SerializeField]
    private int speed;
    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private BoxCollider2D groundCheck;

    private bool facingRight;

    private SpriteRenderer sprite;
    [SerializeField]
    private bool onBoard;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    private bool jumping;
    public int totalJump;
    private int maxJump;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        grounded = true;
        maxJump = 0;
        jumping = false;
        onBoard = false;
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimations();

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
            grounded = false;
            maxJump = totalJump;

            if (onBoard == true)
            {
                onBoard = false;
            }
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);
        if (onBoard)
        {
            Barco.velocity = new Vector2(move * speed, rb2D.velocity.y);
        }

        if ((move > 0f && facingRight) || (move < 0f && !facingRight))
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (jumping)
        {
            jumping = false;
            maxJump--;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            rb2D.AddForce(new Vector2(0f, jumpforce));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NextLevel2"))
        {
            SceneManager.LoadScene("09DialogueEnd");

        }

        if (other.gameObject.tag == "Barco")
        {
            onBoard = true;
            grounded = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (other.gameObject.tag == "NextLevel")
            {
            SceneManager.LoadScene("08Fase2");
        }


        if (other.CompareTag("Hole1"))
        {
            SceneManager.LoadScene("07Fase1");

        }

        if (other.CompareTag("Hole2"))
        {
            SceneManager.LoadScene("08Fase2");

        }

    }

    private void PlayerRespawn()
    {

        transform.position = playInitialPosition;

    }

    private void SetAnimations()
    {
        anim.SetFloat("VelY", rb2D.velocity.y);
        anim.SetBool("JumpFall", !grounded);
        anim.SetBool("Walk2", (rb2D.velocity.x != 0f));

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("End"))
            SceneManager.LoadScene("09DialogueEnd");
    }

   
    
}
