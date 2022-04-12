using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update


    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Awake()
    {
        targetPosition = new Vector3(0,0);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }


    // Update is called once per frame
    private void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        Debug.Log(toPosition);
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(toPosition.y-fromPosition.y, toPosition.x-fromPosition.x)*180 / Mathf.PI;
        pointerRectTransform.localEulerAngles = new Vector3(0,0,angle);
    }
}
