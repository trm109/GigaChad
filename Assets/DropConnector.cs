using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropConnector : MonoBehaviour
{
    public GameObject brassknucklesCO;
    public GameObject swordCO;
    public GameObject morningstarCO;
    public GameObject axeCO;

    // Start is called before the first frame update
    void Start()
    {
        EnemyDrop.brassknuckles = brassknucklesCO;
        EnemyDrop.sword = swordCO;
        EnemyDrop.morningstar = morningstarCO;
        EnemyDrop.axe = axeCO;
    }

}
