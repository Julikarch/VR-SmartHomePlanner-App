using System.Collections;
using System.Collections.Generic;
using scripst;
using scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class tvHelper : MonoBehaviour
{
    public UnityEvent playstoppedUsed;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void PlayStop(){
        var a = FindObjectsOfType<ControlSystemHelper>();
        var canvas = this.gameObject.transform.Find("Canvas").gameObject;
        if(canvas != null && canvas.activeSelf){
            if(this.gameObject.GetComponent<VideoPlayer>().isPlaying){
                StopVideo();
                foreach(ControlSystemHelper item in a)
                {
                    item.TVOn("Stopped");
                }
            } else {
                PlayVideo();
                foreach(ControlSystemHelper item in a)
                {
                    item.TVOn("Playing");
                }
            }
        }
    }

    public void ChangeAudio(TMP_Dropdown dropdown){
        if(dropdown.options[dropdown.value].text != "TV"){
            SpawnedObject audio = ObjectSpawnerOwn.objekte.Find(t => t.name.Equals(dropdown.options[dropdown.value].text));
            if(audio == null){
                return;
            }
            audioSource = audio.gameObject.GetComponent<AudioSource>();
        } else {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void PlayVideo(){
        this.gameObject.GetComponent<VideoPlayer>().Play();
        if(audioSource == null){
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
        audioSource.loop = false;
        audioSource.Play();
        playstoppedUsedMethod();
    }

    public void StopVideo(){
        this.gameObject.GetComponent<VideoPlayer>().Stop();
        if(audioSource == null){
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
        audioSource.Stop();
        playstoppedUsedMethod();
    }

    public void playstoppedUsedMethod(){
        playstoppedUsed.Invoke();
    }

}
