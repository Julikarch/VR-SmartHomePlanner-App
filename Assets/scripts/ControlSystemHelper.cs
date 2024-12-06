using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ControlSystemHelper : MonoBehaviour
{
    public TMP_Text clock;
    public TMP_Text Audio;

    public TMP_Text TV;

    public TMP_Text date;

    public int activeField = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = System.DateTime.Now.ToString("HH:mm:ss");
        date.text = System.DateTime.Now.ToString("dd.MM.yyyy");
    }

    public void TVOn(string tvstring){
        TV.text = "Current showing: \n" + "Trailer \n" + tvstring;
    }

    private string audioplaying = "Paused";
    private string audioselected = "Audio 1";
    public void AudioOn(string audiostring){
        audioplaying = audiostring;
        Audio.text = "Audio:\n" + audioselected + "\n" + audioplaying;
    }

    public void AudioChanged(string audiostring){
        audioselected = audiostring;
        Audio.text = "Audio:\n" + audioselected + "\n" + audioplaying;
    }

    public GameObject hinweis;
    public GameObject calendarGO;
    public GameObject clockGO;
    public GameObject Current;
    public GameObject Weather;
    public GameObject TVGo;
    public GameObject AudioGo;

    public void TVMethod(bool value){
        ControlSystemToggleChanged(value, tv: true);
    }

    public void AudioMethod(bool value){
        ControlSystemToggleChanged(value, audio: true);
    }

    public void ClockMethod(bool value){
        ControlSystemToggleChanged(value, clock: true);
    }

    public void CurrentMethod(bool value){
        ControlSystemToggleChanged(value, current: true);
    }

    public void WeatherMethod(bool value){
        ControlSystemToggleChanged(value, weather: true);
    }

    public void CalendarMethod(bool value){
        ControlSystemToggleChanged(value, calendar: true);
    }

    public void ControlSystemToggleChanged(bool value, bool tv = false, bool audio = false, bool clock = false, bool current = false, bool weather = false, bool calendar = false)
    {
        if(value){
            if(activeField >= 4){
                hinweis.SetActive(true);
                StartCoroutine(dismissHinweis(hinweis));
            } else {
                activeField++;
                if(tv){
                    TVGo.SetActive(value);
                } else if(audio){
                    AudioGo.gameObject.SetActive(value);
                } else if(clock){
                    clockGO.SetActive(value);
                } else if(current){
                    Current.SetActive(value);
                } else if(weather){
                    Weather.SetActive(value);
                } else if(calendar){
                    calendarGO.SetActive(value);
                }
            }
        } else {
            activeField--;
            if(tv){
                TVGo.SetActive(value);
            } else if(audio){
                AudioGo.SetActive(value);
            } else if(clock){
                clockGO.SetActive(value);
            } else if(current){
                Current.SetActive(value);
            } else if(weather){
                Weather.SetActive(value);
            } else if(calendar){
                calendarGO.SetActive(value);
            }
        }
    }

    private IEnumerator dismissHinweis(GameObject hinweis){
        yield return new WaitForSeconds(3);
        hinweis.SetActive(false);
    }
}
