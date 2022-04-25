using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    static GameObject[] itemCatalog = new GameObject[4];
    public static void SpawnObjectFromCatalog(
                                int itemNum,
                                Vector3 position,
                                Quaternion rotation,
                                float size){
        if(itemNum > itemCatalog.Length){
            Debug.Log("Err, out of bounds");
        }
        if(position == null){
            position = Vector3.zero;
        }
        if(rotation == null){
            rotation = Quaternion.identity;
        }
        if(size == null){
            size = 1f;
        }
        GameObject obj = itemCatalog[itemNum];
        GameObject placedObj = Instantiate(obj,position,rotation);
        placedObj.transform.localScale = size * placedObj.transform.localScale;
    }
    public static void SpawnObject(
                                GameObject obj,
                                Vector3 position,
                                Quaternion rotation,
                                float size){
        if(position == null){
            position = Vector3.zero;
        }
        if(rotation == null){
            rotation = Quaternion.identity;
        }
        if(size == null){
            size = 1f;
        }
        GameObject placedObj = Instantiate(obj,position,rotation);
        placedObj.transform.localScale = size * placedObj.transform.localScale;
    }
}
