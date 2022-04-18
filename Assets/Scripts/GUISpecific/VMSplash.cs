using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VMSplash : MonoBehaviour
{
    [SerializeField] float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0.0f)
            timer -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
