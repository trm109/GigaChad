using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Public Variables

    //Private variables.
    private GameObject player;
    private Vector3 initialOffset;
    // Start is called before the first frame update
    void LateStart()
    {
        player = GetComponent<GetPlayer>().player;
        initialOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + initialOffset;
    }
}
