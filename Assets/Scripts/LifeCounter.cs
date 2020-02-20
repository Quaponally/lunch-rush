using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public static int lives;

    public Sprite lives_3;
    public Sprite lives_2;
    public Sprite lives_1;
    public Sprite lives_0;

    private void Awake() {
        GetComponent<Image>().sprite = lives_3;
        lives = 3;     
    }
    
    public void loseLife(){
        lives -= 1;
        FindObjectOfType<AudioManager>().Play("order_failed"); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(lives);
        if (lives == 2){
            GetComponent<Image>().sprite = lives_2;
        }
        else if(lives == 1){
            GetComponent<Image>().sprite = lives_1;
        }
        else if(lives == 0){
            GetComponent<Image>().sprite = lives_0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
