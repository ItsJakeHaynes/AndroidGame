using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rigidB;
    public float moveSpeed;
    public float rightScreenEdge;
    public float leftScreenEdge;

    // Update is called once per frame
    void Update()
    {
        float input;

        if(Input.touchCount > 0) {

            input = Input.GetTouch(0).position.x >= Screen.width / 2 ? 1f : -1f;

        }
        else {

            input = Input.GetAxis("Horizontal");

        }

        transform.Translate(new Vector2(input * speed * Time.deltaTime, 0));
        float currentX = Mathf.Clamp(transform.position.x, LeftBlockTransform.position.x + 1.2f, RightBlockTransform.position.x -1.2f);
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);

        
    }

    public Transform LeftBlockTransform, RightBlockTransform;
    public float speed = 50;
}
