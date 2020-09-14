using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    public int GemValue = 1;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.CompareTag("PlayerBall")) {

            ScoreManager.instance.ChangeScore(GemValue);
        }
    }
}
