 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Prevent from merging into the player/airship    
    [SerializeField]
    private float speed = 5f;
    private Vector3 movement;
    private Transform target;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<GetTarget>().targetObj.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate movement
        movement = (target.position - transform.position).normalized;
        //Apply Speed.
        movement *= speed * Time.deltaTime;
        //Apply to relative rotation.
        rb.velocity = new Vector3(movement.x,0,movement.z);
    }

}
