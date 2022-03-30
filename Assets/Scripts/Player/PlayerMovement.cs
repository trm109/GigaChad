using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Variables
    public float speed;

    //Private Variables
    private Vector2 movement;
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
        movement = new Vector2(HorizontalInput, VerticalInput).normalized;
        //Apply Speed.
        movement *= speed * Time.deltaTime;
        //Apply to relative rotation.
        transform.position += new Vector3(movement.x,0,movement.y);
    }
}
