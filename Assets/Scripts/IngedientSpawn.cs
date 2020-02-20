using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngedientSpawn : MonoBehaviour, IPointerDownHandler, IDropHandler
{
    public GameObject ingredientPrefab;
    public Canvas canvas;

    public bool hasIngredient;
    private bool occupied;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject ingredient = Instantiate(ingredientPrefab, GetComponent<RectTransform>().position, Quaternion.identity, canvas.transform);
        hasIngredient = true;
        occupied = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        hasIngredient = false;
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = 
                    new Vector2(
                        GetComponent<RectTransform>().anchoredPosition.x - 525f,
                        GetComponent<RectTransform>().anchoredPosition.y + 50f
                    );
            // if(!occupied){
            //     //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            //     // eventData.pointerDrag.transform.SetParent(transform);
            //     // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            //     //     GetComponent<RectTransform>().anchoredPosition;
            //     eventData.pointerDrag.GetComponent<RectTransform>().localPosition = 
            //         new Vector2(
            //             GetComponent<RectTransform>().anchoredPosition.x - 525f,
            //             GetComponent<RectTransform>().anchoredPosition.y + 50f
            //         );
            //     occupied = true;
            // }
            // else{
            //     eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
            //         = eventData.pointerDrag.GetComponent<DragAndDrop>().startLocation;
            // }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasIngredient){
            GameObject ingredient = Instantiate(
                ingredientPrefab, 
                GetComponent<RectTransform>().position, 
                Quaternion.identity, 
                canvas.transform
            );
            hasIngredient = true;
            //occupied = true;
        }
        // else if(
        //     eventData.pointerDrag.GetComponent<RectTransform>().localPosition == 
        //         new Vector2(
        //             GetComponent<RectTransform>().anchoredPosition.x - 525f,
        //             GetComponent<RectTransform>().anchoredPosition.y + 50f
        //         )
        // ) {
        //     hasIngredient = true;
        //     occupied = true;
        // }
        // else{
        //     occupied = false;
        // }
        
    }
}
