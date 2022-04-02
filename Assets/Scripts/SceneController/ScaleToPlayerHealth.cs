using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToPlayerHealth : MonoBehaviour
{

    [SerializeField] public PlayerHealth refObject;
    private float startingPos;
    public float testVal;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.x;
        testVal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(refObject.GetHealth());
        Resize(refObject.GetHealth());
    }

    void Resize(float val)
    {
        transform.localScale = new Vector3(1 * val, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(startingPos - val, transform.position.y, transform.position.z);
    }
}
