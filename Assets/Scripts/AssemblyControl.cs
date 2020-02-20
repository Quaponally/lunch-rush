using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssemblyControl : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("drop");
        if (eventData.pointerDrag != null) {
            Debug.Log("drop");
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = 
                new Vector2(
                    GetComponent<RectTransform>().anchoredPosition.x - 150f,
                    GetComponent<RectTransform>().anchoredPosition.y - 2f
                ); 

            FindObjectOfType<AudioManager>().Play("drop");          
        }
    }

}
