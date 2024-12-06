using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class rotationHelper : MonoBehaviour
{
    public List<CustomOneGrabRotateTransformer> customOneGrabRotateTransformers;
    // Start is called before the first frame update
    public void Updatelist()
    {
        var a = GameObject.FindObjectsByType(typeof(CustomOneGrabRotateTransformer), FindObjectsSortMode.None);
        foreach (var item in a)
        {
            if(item is CustomOneGrabRotateTransformer){
                customOneGrabRotateTransformers.Add((CustomOneGrabRotateTransformer)item);
            }
        }
    }

    public void doStiff(){
        Updatelist();
        foreach(CustomOneGrabRotateTransformer c in customOneGrabRotateTransformers){
            c.enabled = !c.enabled;
        }
    }
}
