using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradeButtonUpdate : MonoBehaviour
{

    [SerializeField] private string targetField = "";
    [SerializeField] private PlayerUpgrades player;

    [SerializeField] private Sprite level0;
    [SerializeField] private Sprite level1;
    [SerializeField] private Sprite level2;
    [SerializeField] private Sprite level3;
    [SerializeField] private Sprite level4;

    // Update is called once per frame
    void Update()
    {
        int lvl = player.GetCurrentLevel(targetField);
        switch (lvl)
        {
            case 0:
                gameObject.GetComponent<Image>().sprite = level0;
                break;
            case 1:
                gameObject.GetComponent<Image>().sprite = level1;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = level2;
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = level3;
                break;
            case 4:
                gameObject.GetComponent<Image>().sprite = level4;
                break;
            default:
                Debug.Log("No defined sprite for level " + lvl);
                break;
        }
    }
}
