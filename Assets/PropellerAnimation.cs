using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerAnimation : MonoBehaviour
{
    public float speed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speed, 0f, 0f);
    }
}