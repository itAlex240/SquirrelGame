using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    float horizontal;
    float vertical;
    public float speed = 100f;
    public float jumpForce = 100f;
    public GameObject player;
    Vector2 direction; 
    public SpriteRenderer sp;
    public Rigidbody2D rb;
    public GameObject GameManager;

    bool isGrounded = false;
    public Transform groundChecker;
    public float checkRadius;
    public LayerMask groundLayer;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(transform.position.x, 1f, transform.position.y);
    }

    void Update()
    {
        //Player Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        groundCheck();

    }
    void FixedUpdate()
    {
        //Bewegungs abfrage X
        if (horizontal > 0)
        {
            rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
            sp.flipX = true;
        }

        if (horizontal < 0)
        {
            rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
            sp.flipX = false;
        }
        //Springen
        if (vertical > 0)
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Nut")
        {
            //Nuss einsammeln
            GameManager.GetComponent<Points>().addPoint(1);
            other.gameObject.SetActive(false);
        }
    }
    void groundCheck()
    {
        //Ground Checker
        Collider2D checker = Physics2D.OverlapCircle(groundChecker.position, checkRadius, groundLayer);

        if (checker != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
