using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class motionDetected : MonoBehaviour
{
    public UnityEvent OnMotionDetected;

    public bool detected = false;

    public bool IsEnabled = false;

    [SerializeField] public BoxCollider moveCollider;
    [SerializeField] public BoxCollider motionCollider;
    [SerializeField] public GameObject MoveObject1;
    [SerializeField] public GameObject MoveObject2;


    public void toggleChanged(bool value){
        if(!value){
            Movable();
        } else {
            Usable();
        }
    }

    public void Movable(){
        IsEnabled = false;
        moveCollider.enabled = true;
        motionCollider.enabled = false;
        MoveObject1.SetActive(true);
        MoveObject2.SetActive(true);
    }

    public void Usable(){
        IsEnabled = true;
        moveCollider.enabled = false;
        motionCollider.enabled = true;
        MoveObject1.SetActive(false);
        MoveObject2.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(IsEnabled && other.tag == "Player"){
            detected = true;
            OnMotionDetected.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(IsEnabled && other.tag == "Player"){
            detected = false;
        }
    }
}
