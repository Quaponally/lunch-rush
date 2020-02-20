using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    public GameObject orderPrefab;
    public float maxTime = 10.0f; 
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ingredient = Instantiate(
            orderPrefab, 
            GetComponent<RectTransform>().position, 
            Quaternion.identity, 
            transform
        ); 

        timer = 0.0f;       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(transform.childCount);

        if(transform.childCount < 5){
            if(timer >= maxTime){
                GameObject ingredient = Instantiate(
                    orderPrefab, 
                    GetComponent<RectTransform>().position, 
                    Quaternion.identity, 
                    transform
                );
                timer = 0.0f;
                //Debug.Log("1st if");
            }
            else if(timer > maxTime/2f){
                int select = Random.Range(0, 10);
                if(select == 0){
                    GameObject ingredient = Instantiate(
                        orderPrefab, 
                        GetComponent<RectTransform>().position, 
                        Quaternion.identity, 
                        transform
                    );
                    timer = 0.0f;
                    //Debug.Log("2nd if");
                }
            }
        }   
    }
}
