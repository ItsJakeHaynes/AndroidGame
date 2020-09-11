using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rigidB;
    public float moveSpeed;
    public float rightScreenEdge;
    public float leftScreenEdge;

    private void Awake() {
        rigidB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchMove();

        
    }

    private void FixedUpdate() {
        
    }

    void TouchMove() {
        if(Input.GetMouseButton(0)) {
           
           
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
           float horizontal = Input.GetAxis("Horizontal");            

            if (touchPos.x < 0) {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * moveSpeed);
                if(transform.position.x < leftScreenEdge) {
                    transform.position = new Vector2(leftScreenEdge, transform.position.y);
                }
            }
            else {
                if(transform.position.x > rightScreenEdge) {
                    transform.position = new Vector2(rightScreenEdge, transform.position.y);
                }
            }

                




            /*if(touchPos.x < 0) {
                //move the paddle to the left
                rigidB.velocity = Vector2.left * moveSpeed;
            }
            else {
                //move the paddle to the right
                rigidB.velocity = Vector2.right * moveSpeed;
            }
        }
        else {
            rigidB.velocity = Vector2.zero;
        }*/
        }
    }
}
