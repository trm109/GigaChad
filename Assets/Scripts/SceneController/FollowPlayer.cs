using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Public Variables

    //Private variables.
    [SerializeField]
    private GameObject player;
    private Vector3 initialOffset;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Referencing!");
        player = GetPlayer.ReturnPlayer();
        initialOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player){
            transform.position = player.transform.position + initialOffset;
        }else{
            player = GetPlayer.ReturnPlayer();
        }
    }
}
