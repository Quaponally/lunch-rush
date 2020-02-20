using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GrillControl : MonoBehaviour, IDropHandler
{
    
    
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            FindObjectOfType<AudioManager>().Play("drop"); 
            // eventData.pointerDrag.transform.SetParent(this.transform);
       
            if (eventData.pointerDrag.GetComponent<BurgerController>() != null) {
                BurgerController burger = eventData.pointerDrag.GetComponent<BurgerController>();
                // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                //     GetComponent<RectTransform>().localPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = 
                    new Vector2(
                        GetComponent<RectTransform>().anchoredPosition.x - 150f,
                        GetComponent<RectTransform>().anchoredPosition.y - 2f
                    );
                
                burger.isCooking = true;
                FindObjectOfType<AudioManager>().PlayOneShot("frying");
                 
            }
            else {
                eventData.pointerDrag.GetComponent<RectTransform>().localPosition = 
                    new Vector2(
                        GetComponent<RectTransform>().anchoredPosition.x - 150f,
                        GetComponent<RectTransform>().anchoredPosition.y - 2f
                    );
                eventData.pointerDrag.GetComponent<Image>().color = new Color32(70,70,70,255);

                try{
                    eventData.pointerDrag.GetComponent<ToppingControl>().isBurned = true;
                }
                catch{
                    eventData.pointerDrag.GetComponent<BunController>().isBurned = true;
                }
            }
        }
    }

}
