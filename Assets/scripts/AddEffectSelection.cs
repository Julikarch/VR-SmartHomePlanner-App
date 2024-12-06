using System.Collections;
using System.Collections.Generic;
using scripst;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddEffectSelection : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] private GameObject LightPrefab;
    [SerializeField] private GameObject LightPrefab1;
    [SerializeField] private GameObject LightPrefab2;
    [SerializeField] private GameObject LightPrefab3;
    [SerializeField] private GameObject BlindPrefab;
    [SerializeField] private GameObject BlindPrefab1;
    [SerializeField] private GameObject SpeakerPrefab;
    [SerializeField] private GameObject SpeakerPrefab1;
    [SerializeField] private GameObject SpeakerPrefab2;
    [SerializeField] private GameObject AirConditionerPrefab;
    [SerializeField] private GameObject AirConditionerPrefab1;
    [SerializeField] private GameObject AirPurifierPrefab;
    [SerializeField] private GameObject AirPurifierPrefab1;
    [SerializeField] private GameObject AirPurifierPrefab2;
    [SerializeField] private GameObject AirPurifierPrefab3;
    [SerializeField] private GameObject TVPrefab;
    [SerializeField] private GameObject TVPrefab1;
    [SerializeField] private GameObject TVPrefab2;
    [SerializeField] private GameObject TVPrefab3;
    [SerializeField] private GameObject TVPrefab4;
    [SerializeField] private GameObject CoffeePrefab;
    [SerializeField] private GameObject CoffeePrefab1;
    [SerializeField] private GameObject CancelPrefab;
    [SerializeField] private GameObject Parent;

    private int? Reihen = null;

public void AddOptions(TypVonObject typVonObject, int? Reihen = null){
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
                // GameObject purifierObject2 = Instantiate(AirPurifierPrefab2, Parent.transform);
                // purifierObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirPurifierPrefab2);});
                // GameObject purifierObject3 = Instantiate(AirPurifierPrefab3, Parent.transform);
                // purifierObject3.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(AirPurifierPrefab3);});
                break;
            case TypVonObject.BLIND:
                GameObject blindObject = Instantiate(BlindPrefab, Parent.transform);
                blindObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindPrefab);});
                GameObject blindObject1 = Instantiate(BlindPrefab1, Parent.transform);
                blindObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(BlindPrefab1);});
                break;
            case TypVonObject.LAMP:
                GameObject lightObject = Instantiate(LightPrefab, Parent.transform);
                lightObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab);});
                GameObject lightObject1 = Instantiate(LightPrefab1, Parent.transform);
                lightObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab1);});
                GameObject lightObject2 = Instantiate(LightPrefab2, Parent.transform);
                lightObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab2);});
                GameObject lightObject3 = Instantiate(LightPrefab3, Parent.transform);
                lightObject3.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(LightPrefab3);});
                break;
            case TypVonObject.SPEAKER:
                GameObject speakerObject = Instantiate(SpeakerPrefab, Parent.transform);
                speakerObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(SpeakerPrefab);});
                GameObject speakerObject1 = Instantiate(SpeakerPrefab1, Parent.transform);
                speakerObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(SpeakerPrefab1);});
                GameObject speakerObject2 = Instantiate(SpeakerPrefab2, Parent.transform);
                speakerObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(SpeakerPrefab2);});
                break;
            case TypVonObject.TV:
                GameObject tvObject = Instantiate(TVPrefab, Parent.transform);
                tvObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab);});
                GameObject tvObject1 = Instantiate(TVPrefab1, Parent.transform);
                tvObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab1);});
                GameObject tvObject2 = Instantiate(TVPrefab2, Parent.transform);
                tvObject2.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab2);});
                GameObject tvObject3 = Instantiate(TVPrefab3, Parent.transform);
                tvObject3.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab3);});
                GameObject tvObject4 = Instantiate(TVPrefab4, Parent.transform);
                tvObject4.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(TVPrefab4);});
                break;
            case TypVonObject.COFFEE:
                GameObject coffeeObject = Instantiate(CoffeePrefab, Parent.transform);
                coffeeObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(CoffeePrefab);});
                GameObject coffeeObject1 = Instantiate(CoffeePrefab1, Parent.transform);
                coffeeObject1.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(CoffeePrefab1);});
                break;
            default:
                // Code for unknown type
                break;
        }
        GameObject CancelObject = Instantiate(CancelPrefab, Parent.transform);
        CancelObject.GetComponentInChildren<Button>().onClick.AddListener(delegate {OnButtonClick(CancelPrefab, true);});
        if(Reihen != null){
            this.Reihen = Reihen;
        }
        Parent.SetActive(false);
        Parent.SetActive(true);
    }

    private UnityAction OnButtonClick(GameObject gameObject, bool cancel = false)
    {
        if(cancel){
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddEffect.SetActive(false);
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
            DeleteSelection();
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().automationDeaktivieren.Aktivieren();
            return null;
        }
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().ListAddEffect.SetActive(false);
        GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().LibraryPage.SetActive(true);
        if(gameObject.name.Equals("Speaker 2")){
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddEffectFunc(gameObject, Prefab, speaker: true, ReihenCurrentEff: Reihen, typ: AutomationManager.aktTypEff);
        } else if(gameObject.name.Equals("Lamp 2")){
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddEffectFunc(gameObject, Prefab, lampe: true, ReihenCurrentEff: Reihen, typ: AutomationManager.aktTypEff);
        } else if(gameObject.name.Equals("Lamp 3")){
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddEffectFunc(gameObject, Prefab, lampeInt: true, ReihenCurrentEff: Reihen, typ: AutomationManager.aktTypEff);
        } else if(gameObject.name.Equals("TV 4")){
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddEffectFunc(gameObject, Prefab, tv: true, ReihenCurrentEff: Reihen, typ: AutomationManager.aktTypEff);
        } else {
            GameObject.FindGameObjectWithTag("automationManager").GetComponent<AutomationManager>().AddEffectFunc(gameObject, Prefab, ReihenCurrentEff: Reihen, typ: AutomationManager.aktTypEff);
        }
        Reihen = null;
        AutomationManager.aktTypEff = TypVonObject.NONE;
        DeleteSelection();
        return null;
    }

    public void DeleteSelection()
    {
        for(int i = Parent.transform.childCount - 1; i >= 0; i--){
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
        // foreach(Transform child in Parent.transform)
        // {
        //     Destroy(child.gameObject);
        // }
    }
}
