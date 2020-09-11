using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    Rigidbody2D rb;
    public float bounceForce;

    public float maxSpeed = 350f;

    bool GameStarted;

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
    }

    void StartInitalBounce() {

        //Vector2 randomDirection = new Vector2(Random.Range(-1,  1),   1);
        //rb.AddForce(randomDirection * 10, ForceMode2D.Impulse);

        rb = GetComponent<Rigidbody2D> ();
        rb.AddForce(Vector2.up * maxSpeed);
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
}
