using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayConditioner : MonoBehaviour
{

    public AudioClip start;
    public AudioClip mid;
    public AudioClip midloop;
    public AudioClip end;

    public Toggle toggle;

    public bool play = false;

    public AudioSource audioSource;

    private Coroutine startroutine;

    void Start()
    {
        if(audioSource == null)
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void StartAudio()
    {
        if(play == true)
        {
            return;
        }
        play = true;
        toggle.isOn = true;
        startroutine = StartCoroutine(StartAudioIntern());
    }

    public IEnumerator StartAudioIntern()
    {
        audioSource.PlayOneShot(start);
        yield return new WaitForSeconds(start.length - 0.1f);
        audioSource.PlayOneShot(mid);
        yield return new WaitForSeconds(mid.length);
        while(play){
            audioSource.PlayOneShot(midloop);
            yield return new WaitForSeconds(midloop.length-1f);
        }
        // audioSource.clip = midloop;
        // audioSource.loop = true;
        // audioSource.Play();
        // startroutine = null;
    }

    public void EndAudio()
    {
        if(play == false)
        {
            return;
        }
        play = false;
        toggle.isOn = false;
        if(startroutine != null)
        {
            StopCoroutine(startroutine);
        }
        audioSource.Stop();
        audioSource.PlayOneShot(end);
        // audioSource.Stop();
        // audioSource.loop = false;
    }

    public void ToggleChanged(bool value)
    {
        if(value)
        {
            StartAudio();
        }
        else
        {
            EndAudio();
        }
    }

    public void AnimConditioner(bool value){
        if(value){
            gameObject.GetComponent<Animator>().SetBool("Close", false);
            gameObject.GetComponent<Animator>().SetBool("Open", true);
        } else {
            gameObject.GetComponent<Animator>().SetBool("Open", false);
            gameObject.GetComponent<Animator>().SetBool("Close", true);
        }
    }
}
