using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offsetPosition = new Vector3(0,1,0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gizmos.Drawline(transform.position, transform.position+transform.forward*5);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(offsetPosition, offsetPosition+transform.forward*5);
    }
}
