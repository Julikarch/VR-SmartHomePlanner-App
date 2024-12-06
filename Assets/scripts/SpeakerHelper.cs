using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpeakerHelper : MonoBehaviour
{
    public UnityEvent playpauseUsed;

    public AudioClip Audio1;
    public AudioClip Audio2;
    public AudioClip Audio3;
    public AudioClip Audio4;

    public void playpauseUsedMethod(){
        playpauseUsed.Invoke();
    }

    public void PlayPause(){
        var a = FindObjectsOfType<ControlSystemHelper>();
        if(gameObject.GetComponent<AudioSource>().isPlaying){
            gameObject.GetComponent<AudioSource>().Pause();
            foreach(ControlSystemHelper c in a)
            {
                c.AudioOn("Stopped");
            }
        } else {
            gameObject.GetComponent<AudioSource>().Play();
            foreach(ControlSystemHelper c in a)
            {
                c.AudioOn("Playing");
            }
        }
        playpauseUsedMethod(); 
    }

    public void changeMusic(TMP_Dropdown change){
        if(change.value.ToString().Contains("1")){
            gameObject.GetComponent<AudioSource>().clip = Audio1;
        } else if(change.value.ToString().Contains("2")){
            gameObject.GetComponent<AudioSource>().clip = Audio2;
        } else if(change.value.ToString().Contains("3")){
            gameObject.GetComponent<AudioSource>().clip = Audio3;
        } else if(change.value.ToString().Contains("4")){
            gameObject.GetComponent<AudioSource>().clip = Audio4;
        }
        var a = FindObjectsOfType<ControlSystemHelper>();
        foreach(ControlSystemHelper c in a)
        {
            c.AudioChanged(change.options[change.value].text);
        }
    }
}
