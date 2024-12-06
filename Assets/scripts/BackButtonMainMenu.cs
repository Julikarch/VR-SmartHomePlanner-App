using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonMainMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject Library1;
    [SerializeField]
    public GameObject Library2;
    [SerializeField]
    public GameObject Library3;
    [SerializeField]
    public GameObject backBtn;

    public void BackPressed(){
        if(Library2.activeSelf){
            Library2.SetActive(false);
            Library1.SetActive(true);
            backBtn.SetActive(false);
        }
        else if(Library3.activeSelf){
            Library3.SetActive(false);
            Library2.SetActive(true);
        }
        else{
            Debug.Log("No active library");
        }
    }
}
