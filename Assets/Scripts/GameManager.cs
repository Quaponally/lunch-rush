using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 1f;

    public GameObject gameOverUI;
    public GameObject orders;

    public void EndGame(){
        if(!gameHasEnded){
            gameHasEnded = true;
            Debug.Log("GAME OVER!");

            gameOverUI.SetActive(true);
            orders.SetActive(false);

            //Invoke("Restart", restartDelay);
        }
        
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
