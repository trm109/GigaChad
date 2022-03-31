using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnLeftClick();
        OnRightClick();
    }
    private void OnLeftClick(){
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Left Click");
            //Some Attack
        }
    }
    private void OnRightClick(){
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Right Click");
            //Some Secondary Attack
        }
    }
}
