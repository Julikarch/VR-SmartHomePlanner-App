using System;
using System.Collections;
using System.Collections.Generic;
using scripst;
using scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddDeviceSelection : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject LightPrefab;
    [SerializeField] private GameObject LightSwitchPrefab;
    [SerializeField] private GameObject BlindSwitchPrefab;
    [SerializeField] private GameObject MotionsensorPrefab;
    [SerializeField] private GameObject BlindPrefab;
    [SerializeField] private GameObject SpeakerPrefab;
    [SerializeField] private GameObject AirConditionerPrefab;
    [SerializeField] private GameObject AirPurifierPrefab;
    [SerializeField] private GameObject AirSensorPrefab;
    [SerializeField] private GameObject ControlSystemPrefab;
    [SerializeField] private GameObject TVPrefab;
    [SerializeField] private GameObject CoffeePrefab;
    [SerializeField] private GameObject CancelPrefab;
    [SerializeField] private GameObject Parent;

    private int? Reihe = null;

    public void AddSelection(int? Reihe = null)
    {
        foreach(SpawnedObject spawned in ObjectSpawnerOwn.objekte){
            switch(spawned.objectType){
                case TypVonObject.LAMP:
                    GameObject lightObject = Instantiate(LightPrefab, Parent.transform);
                    lightObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    lightObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, LightPrefab);
                    });
                    break;
                case TypVonObject.LIGHTSWITCH:
                    GameObject lightswitchObject = Instantiate(LightSwitchPrefab, Parent.transform);
                    lightswitchObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    lightswitchObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, LightSwitchPrefab);
                    });
                    break;
                case TypVonObject.BLINDSWITCH:
                    GameObject blindswitchObject = Instantiate(BlindSwitchPrefab, Parent.transform);
                    blindswitchObject.GetComponentInChildren<TMP_Text>().text = spawned.name;  
                    blindswitchObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, BlindSwitchPrefab);
                    }); 
                    break;
                case TypVonObject.MOTIONSENSOR:
                    GameObject motionsensorObject = Instantiate(MotionsensorPrefab, Parent.transform);
                    motionsensorObject.GetComponentInChildren<TMP_Text>().text = spawned.name;  
                    motionsensorObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, MotionsensorPrefab);
                    });
                    break;
                case TypVonObject.BLIND:
                    GameObject blindObject = Instantiate(BlindPrefab, Parent.transform);
                    blindObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    blindObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType,  spawned.name, BlindPrefab);
                    });
                    break;
                case TypVonObject.SPEAKER:
                    GameObject speakerObject = Instantiate(SpeakerPrefab, Parent.transform);
                    speakerObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    speakerObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, SpeakerPrefab);
                    });
                    break;
                case TypVonObject.AIRCONDITIONER:
                    GameObject conditionerObject = Instantiate(AirConditionerPrefab, Parent.transform);
                    conditionerObject.GetComponentInChildren<TMP_Text>().text = spawned.name;  
                    conditionerObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, AirConditionerPrefab);
                    });
                    break;
                case TypVonObject.AIRPURIFIER:
                    GameObject purifierObject = Instantiate(AirPurifierPrefab, Parent.transform);
                    purifierObject.GetComponentInChildren<TMP_Text>().text = spawned.name;  
                    purifierObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, AirPurifierPrefab);
                    });
                    break;
                case TypVonObject.AIRSENSOR:
                    GameObject airsensorObject = Instantiate(AirSensorPrefab, Parent.transform);
                    airsensorObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    airsensorObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, AirSensorPrefab);
                    });
                    break;
                case TypVonObject.CONTROLSYSTEM:
                    GameObject controlsystemObject = Instantiate(ControlSystemPrefab, Parent.transform);
                    controlsystemObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    controlsystemObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, ControlSystemPrefab);
                    });
                    break;
                case TypVonObject.TV:
                    GameObject tvObject = Instantiate(TVPrefab, Parent.transform);
                    tvObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    tvObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, TVPrefab);
                    });
                    break;
                case TypVonObject.COFFEE:
                    GameObject coffeeObject = Instantiate(CoffeePrefab, Parent.transform);
                    coffeeObject.GetComponentInChildren<TMP_Text>().text = spawned.name;
                    coffeeObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                        OnButtonClick(spawned.objectType, spawned.name, CoffeePrefab);
                    });
                    break;
            }
        }
        GameObject CancelObject = Instantiate(CancelPrefab, Parent.transform);
        CancelObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TypVonObject.LAMP, null, null, true);});
        if(Reihe != null){
            this.Reihe = Reihe;
        }
        Parent.SetActive(false);
        Parent.SetActive(true);
    }

    private void OnButtonClick(TypVonObject objectType, string name, GameObject gameObject, bool cancel = false)
    {
        if(cancel)
        {
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddDevice.SetActive(false);
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
            DeleteSelection();
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().automationDeaktivieren.Aktivieren();
            return;
        }
        GameObject condition = AutomationManagerBottom.AutomationPanels[AutomationManagerBottom.currentActiveIndex].gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/AddCond").gameObject;//  GameObject.FindGameObjectWithTag("addCondition");
        // condition.GetComponent<AddConditionSelection>().DeleteSelection();
        // condition.GetComponent<AddConditionSelection>().AddOptions(objectType);
        AutomationManager.aktTypCond = objectType;
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddDevice.SetActive(false);
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddDeviceFunc(gameObject, name, Prefab, Reihe);
        Reihe = null;

        DeleteSelection();
        // return null;
    }

    public void DeleteSelection()
    {
        for(int i = Parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
    }
}
