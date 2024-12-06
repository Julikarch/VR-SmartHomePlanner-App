using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject lightVolume;
    void LateUpdate()
    {
        // ensure all the light volume quads are camera-facing
        for (int i = 0; i < lightVolume.transform.childCount; i++)
        {
            lightVolume.transform.GetChild(i).rotation = Quaternion.LookRotation(
                (lightVolume.transform.GetChild(i).position - Camera.main.transform.position).normalized);
        }
    }
}
