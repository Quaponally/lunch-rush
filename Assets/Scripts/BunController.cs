using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BunController : MonoBehaviour, IDropHandler
{
    public Sprite meat;
    public Sprite meat_lettuce;
    public Sprite meat_cheese;
    public Sprite meat_cheese_lettuce;
    public Sprite cheese;
    public Sprite lettuce;
    public Sprite cheese_lettuce;

    public bool hasMeat;
    public bool hasCheese;
    public bool hasLettuce;

    public bool isBurned;

    private void Awake() {
        hasCheese = false;
        hasLettuce = false;
        hasMeat = false;
    } 

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null){
            if (eventData.pointerDrag.GetComponent<BurgerController>() != null) {
                BurgerController burger = eventData.pointerDrag.GetComponent<BurgerController>();
                
                if(burger.isCooked){
                    hasMeat = true;
                    Destroy(eventData.pointerDrag);
                }  
            }
            else if(eventData.pointerDrag.GetComponent<ToppingControl>() != null){
                ToppingControl topping = eventData.pointerDrag.GetComponent<ToppingControl>();
                
                if (topping.isLettuce & !topping.isBurned & !isBurned){
                    hasLettuce = true;
                    Destroy(eventData.pointerDrag);
                }
                else if (topping.isCheese & !topping.isBurned & !isBurned){
                    hasCheese = true;
                    Destroy(eventData.pointerDrag);
                }  
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(hasMeat & hasCheese & hasLettuce ){
            GetComponent<Image>().sprite = meat_cheese_lettuce;
        }
        else if(hasCheese & hasLettuce){
            GetComponent<Image>().sprite = cheese_lettuce;
        }
        else if(hasMeat & hasLettuce){
            GetComponent<Image>().sprite = meat_lettuce;
        }
        else if(hasMeat & hasCheese){
            GetComponent<Image>().sprite = meat_cheese;
        }
        else if(hasCheese){
            GetComponent<Image>().sprite = cheese;
        }
        else if(hasLettuce){
            GetComponent<Image>().sprite = lettuce;
        } 
        else if(hasMeat){
            GetComponent<Image>().sprite = meat;
        }
        
    }
}
