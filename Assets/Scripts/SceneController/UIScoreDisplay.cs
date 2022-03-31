using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreDisplay : MonoBehaviour
{

    [SerializeField] private PlayerUpgrades player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = player.GetKills().ToString();
    }
}
