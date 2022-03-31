using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
    [SerializeField]
    public GameObject camera;
    public void Start(){
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
}
