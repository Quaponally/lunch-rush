using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button playAgain;
    public Button quit;
    public GameObject score;
    public GameObject scoreDisplay;

    private void Awake() {
        Button play_btn = playAgain.GetComponent<Button>();
		play_btn.onClick.AddListener(PlayOnClick);

        Button quit_btn = quit.GetComponent<Button>();
		quit_btn.onClick.AddListener(QuitOnClick);

        scoreDisplay.GetComponent<Text>().text = "Score: " + score.GetComponent<ScoreCounter>().scoreText.text;

    }

    void PlayOnClick(){
        FindObjectOfType<GameManager>().Restart();
    }

    void QuitOnClick(){
        Application.Quit();
    }
}
