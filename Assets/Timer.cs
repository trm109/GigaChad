using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text txt;

    private void Start() {
        txt = GetComponent<Text>();
    }
    public void UpdateText(float time){
        if(txt == null){
            Debug.LogWarning("Text asset not assigned");
            return;
        }
        txt.text = time.ToString();
    }
    public void ChangeColor(Color c){
        txt.color = c;
    }
}
