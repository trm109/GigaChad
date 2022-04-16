using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//fix spaghetti
public class PlayerLook : MonoBehaviour
{
    //Public Variable
    public float rotateSpeed = 0.1f;

    private bool isdown;       //bool for keeping track of whether player is down
    public void setDown(bool n) { isdown = n; }

    //Private Variable.
    private Vector3 mouse_pos;
    private Transform target;
    private Vector3 object_pos;
    private float angle;
    [SerializeField]
    private Vector3 mousePosition;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        isdown = false;
        target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdown)
        {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = 5.23f; //The distance between the camera and object
            object_pos = Camera.main.WorldToScreenPoint(target.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

        }
    }
}
