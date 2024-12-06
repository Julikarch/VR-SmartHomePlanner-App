using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LightHelper : MonoBehaviour
{
    public UnityEvent enabledUsed;

    [SerializeField] public GameObject light;

    private float red = 1;
    private float green = 1;
    private float blue = 1;

    [SerializeField] public Slider redSlider;
    [SerializeField] public Slider greenSlider;
    [SerializeField] public Slider blueSlider;
    [SerializeField] public Slider intensitySlider;


    public void Update()
    {
        // if(light.name.StartsWith("standing")){
        //     light.transform.rotation = Quaternion.Euler(-90, light.transform.rotation.eulerAngles.y, 0);
        // } else {
        //     light.transform.rotation = Quaternion.Euler(0, light.transform.rotation.eulerAngles.y, 0);
        // }
    }

    public void enabledUsedMethod(){
        enabledUsed.Invoke();
    }

    public void setRed(float value){
        red = value;
        this.gameObject.GetComponent<Light>().color = new Color(red, green, blue);
    }

    public void setGreen(float value){
        green = value;
        this.gameObject.GetComponent<Light>().color = new Color(red, green, blue);
    }

    public void setBlue(float value){
        blue = value;
        this.gameObject.GetComponent<Light>().color = new Color(red, green, blue);
    }

    public void setIntensity(float value){
        this.gameObject.GetComponent<Light>().intensity = value;
    }

    public void colorChanged(float red, float green, float blue){
        redSlider.value = red;
        greenSlider.value = green;
        blueSlider.value = blue;
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.gameObject.GetComponent<Light>().color = new Color(red, green, blue);
    }

    public void intensityChanged(float intensity){
        intensitySlider.value = intensity;
        this.gameObject.GetComponent<Light>().intensity = intensity;
    }
}
