using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIconManager : MonoBehaviour
{
    public Image img;
    private void Start() {

    }
    public void UpdateIcon(Sprite newIcon){
        img.sprite = newIcon;
    }
}
