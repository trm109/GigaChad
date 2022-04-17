using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointer : MonoBehaviour
{
    [SerializeField]
    public GameObject pointer;
    public void Awake(){
        pointer = GameObject.FindGameObjectWithTag("Pointer");
        //Debug.Log("GETPOINTER");
    }
}
