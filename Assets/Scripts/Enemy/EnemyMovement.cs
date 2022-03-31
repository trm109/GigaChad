using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector3 movement;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<GetTarget>().targetObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //calculate movement
        movement = (target.position - transform.position).normalized;
        //Apply Speed.
        movement *= speed * Time.deltaTime;
        //Apply to relative rotation.
        transform.position += new Vector3(movement.x,0,movement.z);
    }

}
