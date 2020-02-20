using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashControl : MonoBehaviour, IDropHandler
{
    GameObject trash;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        
        if (eventData.pointerDrag != null) {
            FindObjectOfType<AudioManager>().Play("drop"); 
            trash = eventData.pointerDrag;
            // trash.GetComponent<RectTransform>().transform = transform;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            StartCoroutine(ExecuteAfterTime(0.1f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    
        Destroy(trash);
    }
}
