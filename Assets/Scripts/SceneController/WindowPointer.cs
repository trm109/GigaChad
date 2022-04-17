using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPointer : MonoBehaviour
{
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        targetPosition = new Vector3(0,0,18);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    private void Update()
    {
         Vector3 toPosition = targetPosition;
         Vector3 fromPosition = Camera.main.transform.position;
         fromPosition.y = 0f;
	 Vector3 dir = (toPosition - fromPosition).normalized;
	 float angle = Mathf.Atan2(fromPosition.z-toPosition.z, fromPosition.x-toPosition.x)*180 / Mathf.PI;   
	 pointerRectTransform.localEulerAngles = new Vector3(0,0,angle+90);

	

	
    }
}
