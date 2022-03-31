using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
    [SerializeField]
    public GameObject mCamera;
    public void Start(){
        mCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
}
