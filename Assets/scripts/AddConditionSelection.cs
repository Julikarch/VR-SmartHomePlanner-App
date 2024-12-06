using System;
using System.Collections;
using System.Collections.Generic;
using scripst;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddConditionSelection : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject LightPrefab;
    [SerializeField] private GameObject LightPrefab1;
    [SerializeField] private GameObject LightSwitchPrefab;
    [SerializeField] private GameObject LightSwitchPrefab1;
    [SerializeField] private GameObject BlindSwitchPrefab;
    [SerializeField] private GameObject BlindSwitchPrefab1;
    [SerializeField] private GameObject MotionsensorPrefab;
    [SerializeField] private GameObject BlindPrefab;
    [SerializeField] private GameObject BlindPrefab1;
    [SerializeField] private GameObject SpeakerPrefab;
    [SerializeField] private GameObject SpeakerPrefab1;
    [SerializeField] private GameObject AirConditionerPrefab;
    [SerializeField] private GameObject AirConditionerPrefab1;
    [SerializeField] private GameObject AirPurifierPrefab;
    [SerializeField] private GameObject AirPurifierPrefab1;
    [SerializeField] private GameObject AirSensorPrefab;
    [SerializeField] private GameObject AirSensorPrefab1;
    [SerializeField] private GameObject AirSensorPrefab2;
    [SerializeField] private GameObject ControlSystemPrefab;
    [SerializeField] private GameObject TVPrefab;
    [SerializeField] private GameObject TVPrefab1;
    [SerializeField] private GameObject CoffeePrefab;
    [SerializeField] private GameObject CancelPrefab;
    [SerializeField] private GameObject Parent;

    private int? Reihe = null;

    public void AddOptions(TypVonObject typVonObject, int? index = null, int? dIndex = null){
        switch(typVonObject){
            case TypVonObject.AIRCONDITIONER:
                GameObject conditionerObject = Instantiate(AirConditionerPrefab, Parent.transform);
                conditionerObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirConditionerPrefab);});
                GameObject conditionerObject1 = Instantiate(AirConditionerPrefab1, Parent.transform);
                conditionerObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirConditionerPrefab1);});
                break;
            case TypVonObject.AIRPURIFIER:
                GameObject purifierObject = Instantiate(AirPurifierPrefab, Parent.transform);
                purifierObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirPurifierPrefab);});
                GameObject purifierObject1 = Instantiate(AirPurifierPrefab1, Parent.transform);
                purifierObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirPurifierPrefab1);});
                break;
            case TypVonObject.AIRSENSOR:
                GameObject airsensorObject = Instantiate(AirSensorPrefab, Parent.transform);
                airsensorObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirSensorPrefab);});
                // GameObject airsensorObject1 = Instantiate(AirSensorPrefab1, Parent.transform);
                // airsensorObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirSensorPrefab1);});
                // GameObject airsensorObject2 = Instantiate(AirSensorPrefab2, Parent.transform);
                // airsensorObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirSensorPrefab2);});
                break;
            case TypVonObject.BLIND:
                GameObject blindObject = Instantiate(BlindPrefab, Parent.transform);
                blindObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindPrefab);});
                GameObject blindObject1 = Instantiate(BlindPrefab1, Parent.transform);
                blindObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindPrefab1);});
                break;
            case TypVonObject.BLINDSWITCH:
                GameObject blindswitchObject = Instantiate(BlindSwitchPrefab, Parent.transform);
                blindswitchObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindSwitchPrefab);});
                GameObject blindswitchObject1 = Instantiate(BlindSwitchPrefab1, Parent.transform);
                blindswitchObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindSwitchPrefab1);});
                break;
            case TypVonObject.LAMP:
                GameObject lightObject = Instantiate(LightPrefab, Parent.transform);
                lightObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab);});
                GameObject lightObject1 = Instantiate(LightPrefab1, Parent.transform);
                lightObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab1);});
                break;
            case TypVonObject.LIGHTSWITCH:
                GameObject lightswitchObject = Instantiate(LightSwitchPrefab, Parent.transform);
                lightswitchObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightSwitchPrefab);});
                GameObject lightswitchObject1 = Instantiate(LightSwitchPrefab1, Parent.transform);
                lightswitchObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightSwitchPrefab1);});
                break;
            case TypVonObject.MOTIONSENSOR:
                GameObject motionsensorObject = Instantiate(MotionsensorPrefab, Parent.transform);
                motionsensorObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(MotionsensorPrefab);});
                break;
            case TypVonObject.SPEAKER:
                GameObject speakerObject = Instantiate(SpeakerPrefab, Parent.transform);
                speakerObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(SpeakerPrefab);});
                GameObject speakerObject1 = Instantiate(SpeakerPrefab1, Parent.transform);
                speakerObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(SpeakerPrefab1);});
                break;
            case TypVonObject.CONTROLSYSTEM:
                GameObject controlsystemObject = Instantiate(ControlSystemPrefab, Parent.transform);
                controlsystemObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(ControlSystemPrefab);});
                break;
            case TypVonObject.TV:
                GameObject tvObject = Instantiate(TVPrefab, Parent.transform);
                tvObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab);});
                GameObject tvObject1 = Instantiate(TVPrefab1, Parent.transform);
                tvObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab1);});
                break;
            case TypVonObject.COFFEE:
                GameObject coffeeObject = Instantiate(CoffeePrefab, Parent.transform);
                coffeeObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(CoffeePrefab);});
                break;
            default:
                // Code for unknown type
                break;
        }
        GameObject CancelObject = Instantiate(CancelPrefab, Parent.transform);
        CancelObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(null, true);});
        if(Reihe != null){
            this.Reihe = Reihe;
        }
        Parent.SetActive(false);
        Parent.SetActive(true);
    }

    private UnityAction OnButtonClick(GameObject gameObject, bool cancel = false)
    {
        if(cancel)
        {
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddCond.SetActive(false);
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
            DeleteSelection();
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().automationDeaktivieren.Aktivieren();
            return null;
        }
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddCond.SetActive(false);
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddConditionFunc(gameObject, Prefab, ReihenCurrentCon: Reihe, typ: AutomationManager.aktTypCond);
        Reihe = null;
        AutomationManager.aktTypCond = TypVonObject.NONE;

        DeleteSelection();
        return null;
    }

    public void DeleteSelection()
    {
        for(int i = Parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
        // foreach(Transform child in Parent.transform)
        // {
        //     Destroy(child.gameObject);
        // }
    }
}
