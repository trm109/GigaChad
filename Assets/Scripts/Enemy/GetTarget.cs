using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{
    bool playertarget = false;

    public void Target()
    {
        float n = Random.Range(0, 10);
        if (n < 5) { playertarget = true}
    }
}
