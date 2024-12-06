using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextHelperMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ColorWhite(){
        this.gameObject.GetComponent<TMP_Text>().color = Color.white;
    }

    public void ColorBlack(){
        this.gameObject.GetComponent<TMP_Text>().color = Color.black;
    }
}
