using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    Rigidbody2D rb;
    public float bounceForce;

    public float startingSpeed = 350f;

    [SerializeField]
    private float maxVelocity = 9f;

    bool GameStarted;

    public Animator animator;

    public void Awake() {

       rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!GameStarted) {

            if(Input.anyKeyDown) {

                GameStarted = true;
                StartInitalBounce();
                GameManager.instance.GameStart();
            }
        }

        var vel = rb.velocity;
        var speed = vel.magnitude;

        rb.velocity = Vector2.ClampMagnitude(vel, maxVelocity);
        Debug.Log(speed);

    }

    void StartInitalBounce() {

        animator.SetTrigger("GameStart");

        rb = GetComponent<Rigidbody2D> ();
        rb.AddForce(Vector2.up * startingSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "CheckFall") {
            
            GameManager.instance.Restart();

        }

        else if (collision.gameObject.tag =="Paddle") {

            GameManager.instance.UpdateScore();
            rb.AddForce(Vector2.left * 22);
        }

        else if (collision.gameObject.tag == "CheckCollide") {
            rb.AddForce(Vector2.down * 20);
        }

    }

    private void OnTriggerEnter2D (Collider2D collision) {

        if(collision.gameObject.CompareTag("Gem")) {

            Destroy(collision.gameObject);

        }
    }
}
