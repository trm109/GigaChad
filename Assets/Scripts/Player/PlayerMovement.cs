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
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public void setSpeed(float n) { speed = n; }

    public float getSpeed() { return speed; }

    void Update()
    {
        //Get input
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        //Combine and normalize.
        movement = new Vector2(HorizontalInput, VerticalInput).normalized;
        //Apply Speed.
        movement *= speed * Time.deltaTime;
        if((VerticalInput == 0) & (HorizontalInput==0)){
            movement = Vector2.zero;
        }
        //Apply to relative rotation.
        rb.velocity = new Vector3(movement.x,0,movement.y);
    }
}
