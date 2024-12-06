using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationToPlayer : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject gameObject;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3( Camera.main.transform.position.x, 
                                       gameObject.transform.position.y, 
                                       Camera.main.transform.position.z ) ;
        gameObject.transform.LookAt( targetPostition ) ;
    }
}
