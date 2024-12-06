using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPurifierHelper : MonoBehaviour
{

    public bool cooling = true;
    public bool heating = false;

    public GameObject blue;
    public GameObject red;

    public void CoolingChanged(bool value){
        cooling = !value;
        heating = value;
    }

    public void ActivateShader(bool value){
        if(value){
            if(cooling){
                blue.SetActive(true);
                red.SetActive(false);
            } else if(heating){
                blue.SetActive(false);
                red.SetActive(true);
            }
        } else {
            blue.SetActive(false);
            red.SetActive(false);
        }
    }

    public void DeactivateShader(){
        blue.SetActive(false);
        red.SetActive(false);
    }
}
