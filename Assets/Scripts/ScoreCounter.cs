using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    private void Start() {
        score = 0;
        scoreText.text = "$ 0";
    }

    public void changeScore(int delta){
        score += delta;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "$ " + score.ToString();
        Debug.Log(score);
    }
}
