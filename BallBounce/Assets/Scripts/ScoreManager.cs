﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    public TextMeshProUGUI text;

    int score;

    void Start()
    {
        if(instance == null) {
            instance = this;
        }
    }

    public void ChangeScore(int GemValue) {

        score += GemValue;
        text.text = " x" + score.ToString(); 

    }

}