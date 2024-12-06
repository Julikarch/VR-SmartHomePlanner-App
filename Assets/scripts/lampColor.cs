using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lampColor : MonoBehaviour
{
    [SerializeField]
    public Image Background;
    [SerializeField]
    public Slider Red;
    [SerializeField]
    public Slider Green;
    [SerializeField]
    public Slider Blue;

    [SerializeField]
    public TMP_Text Inten;
    [SerializeField]
    public Slider Intensity;

    public void UpdateColor(){
        Background.color = new Color(Red.value, Green.value, Blue.value);
    }

    public void UpdateIntensity(){
        Inten.text = Intensity.value.ToString();
    }
}
