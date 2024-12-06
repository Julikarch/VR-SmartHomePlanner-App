using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AirSensorHelper : MonoBehaviour
{
    public UnityEvent buttonPressed;

    public void buttonPressedMethod(){
        buttonPressed.Invoke();
    }
}
