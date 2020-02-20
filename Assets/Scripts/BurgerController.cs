using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BurgerController : MonoBehaviour, IDragHandler
{
    public bool isCooking;
    public bool isBurned;
    public bool isCooked;

    public float cookTime = 4f;
    float timer;

    public Image image;

    // Start is called before the first frame update
    void Awake()
    {
        isCooking = false;
        isBurned = false;
        isCooked = false; 
        timer = cookTime;       
    }

    public void OnDrag(PointerEventData eventData) {
        if(isCooking){
            FindObjectOfType<AudioManager>().Stop("frying");
        }
        isCooking = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking) {
            timer -= Time.deltaTime;
            if (timer < -3){
                isBurned = true;
                isCooked = false;
                image.GetComponent<Image>().color = new Color32(70,70,70,255);
            }
            else if (timer < 0){
                isCooked = true;
                image.GetComponent<Image>().color = new Color32(169,122,127,255);
            }
        }       
        
    }
}
