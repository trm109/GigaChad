using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Variables
    public float speed;

    //Private Variables
    private Vector2 combinedMovement;
    private float HorizontalInput;
    private float VerticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        //Combine and normalize.
        combinedMovement = new Vector2(HorizontalInput, VerticalInput).normalized;
        //Apply Speed.

        //Apply to relative rotation.
    }
}
