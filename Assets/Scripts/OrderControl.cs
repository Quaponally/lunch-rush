using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrderControl : MonoBehaviour, IDropHandler
{
    GameObject obj;
    
    public bool needsCheese;
    public bool needsLettuce;
    public Sprite meat_cheese_lettuce_order;
    public Sprite meat_lettuce_order;
    public Sprite meat_cheese_order;
    public Sprite meat_order;
    
    public GameObject scoreBoard;
    public GameObject lifeCounter;


    public float lifetime = 20;
    private float timer;

    private void Awake() {
        FindObjectOfType<AudioManager>().Play("new_order"); 
        timer = lifetime;

        //randomly select values for cheese and lettuce
        int select = Random.Range(0, 4);
        if(select == 0){
            needsCheese = false;
            needsLettuce = false;
        }
        else if(select == 1){
            needsCheese = true;
            needsLettuce = false;
        }
        else if(select == 2){
            needsCheese = false;
            needsLettuce = true;
        }
        else if(select == 3){
            needsCheese = true;
            needsLettuce = true;
        }

        //select appropriate sprite
        if(needsCheese & needsLettuce ){
            GetComponent<Image>().sprite = meat_cheese_lettuce_order;
        }
        else if(needsLettuce){
            GetComponent<Image>().sprite = meat_lettuce_order;
        }
        else if(needsCheese){
            GetComponent<Image>().sprite = meat_cheese_order;
        }
        else{
            GetComponent<Image>().sprite = meat_order;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("drop");
        if (eventData.pointerDrag.GetComponent<BunController>() != null) {
            //Debug.Log("drop");
            obj = eventData.pointerDrag;
            BunController burger = obj.GetComponent<BunController>();

            if(burger.hasMeat && burger.hasCheese == needsCheese && burger.hasLettuce == needsLettuce){
                FindObjectOfType<AudioManager>().Play("add_score"); 
                // move to centre
                obj.GetComponent<RectTransform>().anchoredPosition = 
                    GetComponent<RectTransform>().anchoredPosition;  

                //add to score
                // scoreBoard.GetComponent<ScoreCounter>().score += 5;
                scoreBoard.GetComponent<ScoreCounter>().changeScore(5);

                // delete object
                StartCoroutine(ExecuteAfterTime(0.1f)); 

            }
            else{
                FindObjectOfType<AudioManager>().Play("drop"); 
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
                    = eventData.pointerDrag.GetComponent<DragAndDrop>().startLocation;
            }
                  
        }
        else{
            FindObjectOfType<AudioManager>().Play("drop"); 
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
                = eventData.pointerDrag.GetComponent<DragAndDrop>().startLocation;
            }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    
        Destroy(obj);
        // destroy order
        Destroy(gameObject);
    }

    private void Update() {
        timer -= Time.deltaTime;

        if(timer < 0){
            lifeCounter.GetComponent<LifeCounter>().loseLife();
            Destroy(gameObject);
        }
    }
}
