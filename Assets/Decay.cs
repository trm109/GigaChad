using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float timeToDecay = 7.5f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = timeToDecay;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time < 0) { Destroy(this.gameObject); }
    }
}
