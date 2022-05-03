using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NotificationKey : MonoBehaviour
{
    public static GameObject key_1;
    public static GameObject key_2;
    public static GameObject key_3;
    public static GameObject key_4;
    [SerializeField]
    private int staticInstanceNum = -1;
    private float toggle;
    private void Start() {
        if(staticInstanceNum == -1){
            //Debug.Log("Not assigning static instance.");
        }else{
            //Debug.Log("Assigning Key to static instance: " + staticInstanceNum);
            switch (staticInstanceNum){
                case 1:
                    NotificationKey.key_1 = this.gameObject;
                    break;
                case 2:
                    NotificationKey.key_2 = this.gameObject;
                    break;
                case 3:
                    NotificationKey.key_3 = this.gameObject;
                    break;
                case 4:
                    NotificationKey.key_4 = this.gameObject;
                    break;
                default:
                    Debug.Log("Bad instance num");
                    break;
            }
        }
    }
    private void Update() {
        if((int) Time.realtimeSinceStartup % 2 == 0){
            GetComponent<Image>().color = new Color(.75f,.75f,.75f,.75f);
            //Debug.Log("Boop");
        }else{
            GetComponent<Image>().color =  new Color(.5f,.5f,.5f,.75f);
            //Debug.Log("Beep");
        }
    }
}
