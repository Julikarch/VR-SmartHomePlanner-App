using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class touchButtons : MonoBehaviour
{
    public UnityEvent OnButtonPressed;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            OnButtonPressed.Invoke();
        }
    }
}
