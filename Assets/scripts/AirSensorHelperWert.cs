using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AirSensorHelperWert : MonoBehaviour
{

    public TMP_Text wert;
    public Image background;
    public int wertInt;
    public bool wertSimulieren = true;
    public bool wertSimulierenUeber = false;

    public UnityEvent wertUeber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SimuliereWert());
    }

    public void buttonPressed(Button btn){
        wertSimulieren = !wertSimulieren;
        wertSimulierenUeber = !wertSimulierenUeber;
        if(btn.GetComponent<TMP_Text>().text == "Simulate higher PM2,5 values"){
            btn.GetComponent<TMP_Text>().text = "Simulate normal PM2,5 values";
        } else {
            btn.GetComponent<TMP_Text>().text = "Simulate higher PM2,5 values";
        }
    }

    public IEnumerator SimuliereWert(){
        while(true){
            if(wertSimulieren){
                setWert(Random.Range(0, 100).ToString());
            }
            if(wertSimulierenUeber){
                setWert(Random.Range(50, 100).ToString());
            }
            yield return new WaitForSeconds(3);
            // StartCoroutine(SimuliereWert());
        }
    }

    public void setWert(string wert){
        this.wert.text = wert;
        wertInt = int.Parse(wert);
        if(int.Parse(wert) > 49){
            wertUeber.Invoke();
            background.color = new Color(204/255, 180/255, 0);
        } else {
            background.color = new Color(0/255, 204/255, 0);
        }
    }
}
