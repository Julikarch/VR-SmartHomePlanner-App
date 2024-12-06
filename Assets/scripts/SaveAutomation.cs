using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using scripst;
using scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class SaveAutomation : MonoBehaviour
{
    [SerializeField]
    public AutomationManager automationManager;
    [SerializeField]
    public AutomationManagerBottom automationManagerBottom;
    [SerializeField]
    public TMP_Text NotificationText;
    [SerializeField]
    public GameObject Notification;
    [SerializeField]
    public GameObject Poopup;
    [SerializeField]
    public GameObject Saving;
    [SerializeField]
    public GameObject Saved;

    [SerializeField]
    public AudioClip Audio1;
    [SerializeField]
    public AudioClip Audio2;
    [SerializeField]
    public AudioClip Audio3;
    [SerializeField]
    public AudioClip Audio4;

    public Coroutine not;


    public static List<SavedAutomations> savedAutomations = new List<SavedAutomations>();
    public void Save()
    {
        // Save the automation
        Poopup.SetActive(true);
        Saving.SetActive(true);
        Debug.Log("Automation saved!");
        List<GameObject> conditionObjects = new List<GameObject>();
        List<GameObject> effectObjects = new List<GameObject>();
        foreach(AutomationPanelObjects panel in AutomationManagerBottom.AutomationPanels)
        {
            SavedAutomations savedAutomation = new SavedAutomations();
            savedAutomation.automationPanelObjects = panel;
            savedAutomation.NotificationText = NotificationText;
            savedAutomation.Notification = Notification;
            savedAutomation.name = panel.name;
            savedAutomation.Audio1 = Audio1;
            savedAutomation.Audio2 = Audio2;
            savedAutomation.Audio3 = Audio3;
            savedAutomation.Audio4 = Audio4;
            savedAutomation.saveAutomation = this;
            foreach(ReiheAutomation reiheAutomation in panel.Reihen){
                if(reiheAutomation.ReihenTyp == ReihenTyp.CONDITION){
                    switch(reiheAutomation.second.name){
                        case "Lightswitch(Clone)":
                            SpawnedObject possibleObjects = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjects == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("Lightswitch(Clone)")){
                                if(possibleObjects.gameObject.GetComponent<touchControllerLight>().up){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else if(possibleObjects.gameObject.GetComponent<touchControllerLight>().down){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else{
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjects.gameObject.GetComponent<touchControllerLight>().upPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());
                                    // }
                                });
                                possibleObjects.gameObject.GetComponent<touchControllerLight>().downPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;   
                                    // }
                                });
                            } else {
                                if(possibleObjects.gameObject.GetComponent<touchControllerLight>().up){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else if(possibleObjects.gameObject.GetComponent<touchControllerLight>().down){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else{
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjects.gameObject.GetComponent<touchControllerLight>().upPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;   
                                    // }
                                });
                                possibleObjects.gameObject.GetComponent<touchControllerLight>().downPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());   
                                    // }
                                });
                            }
                            break;
                        case "Blindswitch(Clone)":
                            SpawnedObject possibleObjectsBlindswitch = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsBlindswitch == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("BlindswitchDOWN(Clone)")){
                                if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().up){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().down){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().middle){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().upPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;   
                                    // }
                                });
                                possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().downPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());   
                                    // }
                                });
                            } else {
                                if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().up){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().down){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else if(possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().middle){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().upPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());   
                                    // }
                                });
                                possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().downPressed.AddListener(() => {
                                    // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;   
                                    // }
                                });
                            }
                            possibleObjectsBlindswitch.gameObject.GetComponent<touchControllerRollo>().middlePressed.AddListener(() => {
                                // if(savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                    savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;   
                                // }
                            });
                            break;
                        case "Motionsensor(Clone)":
                            SpawnedObject possibleObjectsMotion = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsMotion == null){
                                break;
                            }
                            if(possibleObjectsMotion.gameObject.GetComponentInChildren<motionDetected>().detected){
                                savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                            } else {
                                savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                            }
                            break;
                        case "TV(Clone)":
                            SpawnedObject possibleObjectsTV = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsTV == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("TV(Clone)")){
                                if(possibleObjectsTV.gameObject.GetComponent<VideoPlayer>().isPlaying){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsTV.gameObject.GetComponent<tvHelper>().playstoppedUsed.AddListener(() => {
                                    // if(possibleObjectsTV != null && possibleObjectsTV.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsTV.gameObject.GetComponent<VideoPlayer>().isPlaying){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        }
                                    // }
                                });
                            } else {
                                if(possibleObjectsTV.gameObject.GetComponent<VideoPlayer>().isPlaying){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                }
                                possibleObjectsTV.gameObject.GetComponent<tvHelper>().playstoppedUsed.AddListener(() => {
                                    // if(possibleObjectsTV != null && possibleObjectsTV.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsTV.gameObject.GetComponent<VideoPlayer>().isPlaying){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        }
                                    // }
                                });
                            }
                            break;
                        case "AirSensor(Clone)":
                            SpawnedObject possibleObjectsAirSensor = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsAirSensor == null){
                                break;
                            }
                            if(possibleObjectsAirSensor.gameObject.GetComponent<AirSensorHelperWert>().wertInt > 25){
                                savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                            } else {
                                savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                            }
                            possibleObjectsAirSensor.gameObject.GetComponent<AirSensorHelperWert>().wertUeber.AddListener(() => {
                                // if(possibleObjectsAirSensor != null && possibleObjectsAirSensor.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                    if(possibleObjectsAirSensor.gameObject.GetComponent<AirSensorHelperWert>().wertInt > 25){
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());
                                    } else {
                                        savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                    }
                                // }
                            });
                            break;  
                        case "AirConditioner(Clone)":
                            SpawnedObject possibleObjectsAirConditioner = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsAirConditioner == null){
                                break;
                            }
                            break;
                        case "AirPurifier(Clone)":
                            SpawnedObject possibleObjectsAirPurifier = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsAirPurifier == null){
                                break;
                            }
                            break;
                        case "Blind(Clone)":
                            SpawnedObject possibleObjectsBlind = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsBlind == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("Blind(Clone)")){
                                int i = possibleObjectsBlind.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
                                float height = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().GetBlendShapeWeight(i);
                                if(height == 0){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsBlind.gameObject.GetComponent<BlindController>().heightUsed.AddListener(() => {
                                    // if(possibleObjectsBlind != null && possibleObjectsBlind.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsBlind.gameObject.GetComponent<BlindController>().GetHeight() == 0){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        }
                                    // }
                                });
                            } else {
                                int i = possibleObjectsBlind.gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh.GetBlendShapeIndex("down");
                                float height = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().GetBlendShapeWeight(i);
                                if(height == gameObject.GetComponent<BlindController>().savedHeight){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                }
                                possibleObjectsBlind.gameObject.GetComponent<BlindController>().heightUsed.AddListener(() => {
                                    // if(possibleObjectsBlind != null && possibleObjectsBlind.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsBlind.gameObject.GetComponent<BlindController>().GetHeight() == gameObject.GetComponent<BlindController>().savedHeight){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        }
                                    // }
                                });
                            }
                            break;
                        case "Speaker(Clone)":
                            SpawnedObject possibleObjectsSpeaker = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsSpeaker == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("Speaker(Clone)")){
                                if(possibleObjectsSpeaker.gameObject.GetComponent<AudioSource>().isPlaying){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsSpeaker.gameObject.GetComponent<SpeakerHelper>().playpauseUsed.AddListener(() => {
                                    // if(possibleObjectsSpeaker != null && possibleObjectsSpeaker.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsSpeaker.gameObject.GetComponent<AudioSource>().isPlaying){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        }
                                    // }
                                });
                            } else {
                                if(possibleObjectsSpeaker.gameObject.GetComponent<AudioSource>().isPlaying){
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                }
                                possibleObjectsSpeaker.gameObject.GetComponent<SpeakerHelper>().playpauseUsed.AddListener(() => {
                                    // if(possibleObjectsSpeaker != null && possibleObjectsSpeaker.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsSpeaker.gameObject.GetComponent<AudioSource>().isPlaying){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        }
                                    // }
                                });
                            }
                            break;
                        case "Light(Clone)":
                            SpawnedObject possibleObjectsLight = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsLight == null){
                                break;
                            }
                            if(reiheAutomation.third.name.Equals("Lamp(Clone)")){
                                if(possibleObjectsLight.gameObject.GetComponentInChildren<Light>().enabled) {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                }
                                possibleObjectsLight.gameObject.GetComponentInChildren<LightHelper>().enabledUsed.AddListener(() => {
                                    // if(possibleObjectsLight != null && possibleObjectsLight.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsLight.gameObject.GetComponentInChildren<Light>().enabled){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                        StartCoroutine(savedAutomation.checkConditions());
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        }   
                                    // }
                                });
                            } else {
                                if(possibleObjectsLight.gameObject.GetComponentInChildren<Light>().enabled) {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, false));
                                } else {
                                    savedAutomation.conditions.Add(new Conditions(reiheAutomation.secondObject, true));
                                }
                                possibleObjectsLight.gameObject.GetComponentInChildren<LightHelper>().enabledUsed.AddListener(() => {
                                    // if(possibleObjectsLight != null && possibleObjectsLight.gameObject != null && savedAutomation != null && savedAutomation.conditions.Count > 0 && reiheAutomation.secondObject != null){
                                        if(possibleObjectsLight.gameObject.GetComponentInChildren<Light>().enabled){
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = false;
                                        } else {
                                            savedAutomation.conditions.Find(e => e.conditionObject.Equals(reiheAutomation.secondObject)).conditionMet = true;
                                            StartCoroutine(savedAutomation.checkConditions());
                                        }
                                    // }
                                });
                            }
                            break;
                        case "Coffee(Clone)":
                            SpawnedObject possibleObjectsMachine = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                            if(possibleObjectsMachine == null){
                                break;
                            }
                            break;
                        
                    }
                } else if(reiheAutomation.ReihenTyp == ReihenTyp.EFFECT){
                    SpawnedObject possibleObjectsLight = ObjectSpawnerOwn.objekte.Find(e => e.name.Equals(reiheAutomation.secondObject));
                    if(possibleObjectsLight == null){
                        break;
                    }
                    Effects effects = new Effects(){
                        conditionObject = possibleObjectsLight.gameObject,
                        secondObject = reiheAutomation.secondObject,
                        thirdObject = reiheAutomation.thirdObject,
                        typ = reiheAutomation.second.name
                    };
                    switch(reiheAutomation.second.name){
                        case "Light(Clone)":
                            // effects.argument = Color.red.a.ToString() + "," + Color.red.b.ToString() + "," + Color.red.g.ToString();
                            if(effects.thirdObject.Equals("LampColor(Clone)")){
                                effects.argument = reiheAutomation.third.transform.Find("Content/Background/Red").GetComponentInChildren<UnityEngine.UI.Slider>().value + "|" 
                                                    + reiheAutomation.third.transform.Find("Content/Background/Green").GetComponentInChildren<UnityEngine.UI.Slider>().value + "|" 
                                                    + reiheAutomation.third.transform.Find("Content/Background/Blue").GetComponentInChildren<UnityEngine.UI.Slider>().value;
                            }
                            if(effects.thirdObject.Equals("LampIntensity(Clone)")){
                                effects.argument = reiheAutomation.third.transform.Find("Content/Background/Intensity").GetComponentInChildren<UnityEngine.UI.Slider>().value.ToString();
                            }
                            break;
                        case "Blind(Clone)":
                            effects.argument = possibleObjectsLight.gameObject.GetComponent<BlindController>().savedHeight.ToString();
                            break;
                        case "Speaker(Clone)":
                            if(effects.thirdObject.Equals("SpeakerAudio(Clone)")){
                                effects.argument = reiheAutomation.third.transform.Find("Content/Background/GeometryDropdown").GetComponentInChildren<Dropdown>().value.ToString();
                            }
                            break;
                        case "AirConditioner(Clone)":
                            break;
                        case "AirPurifier(Clone)":
                            break;
                        case "TV(Clone)":
                            if(effects.thirdObject.Equals("TVOutput(Clone)")){
                                TMP_Dropdown dropdown = reiheAutomation.third.transform.Find("Content/Background/GeometryDropdown").GetComponentInChildren<TMP_Dropdown>();
                                effects.argument = dropdown.options[dropdown.value].text;
                            }
                            break;
                        case "Coffee(Clone)":
                            break;
                    }
                    savedAutomation.effectObjects.Add(effects);
                }
            }
            CheckAutomation(savedAutomation, panel);
            savedAutomations.Clear();
            StartCoroutine(savedAutomation.checkConditions());
            savedAutomations.Add(savedAutomation);
        }
        Saving.SetActive(false);
        Saved.SetActive(true);
        StartCoroutine(DiscardPopup());
    }

    public void DisablePopup(){
        StartCoroutine(RemovePopup());
    }

    public IEnumerator RemovePopup(){
        yield return new WaitForSeconds(0.5f);
        Notification.SetActive(false);
    }

    public IEnumerator DiscardPopup()   {
        yield return new WaitForSeconds(3);
        Saved.SetActive(false);
        Poopup.SetActive(false);
    }

    private void CheckAutomation(SavedAutomations savedAutomation, AutomationPanelObjects panel)
    {   
        bool korrekt = false;
        if(savedAutomation.conditions.Count > 0 && savedAutomation.effectObjects.Count > 0){
            korrekt = true;
        }
        if(korrekt){
            panel.gameObjectButton.transform.Find("correct").gameObject.SetActive(true);// .GetComponent<UnityEngine.UI.Image>().color = Color.green;
        } else {
            panel.gameObjectButton.transform.Find("failure").gameObject.SetActive(true);// .GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
    }

    public class SavedAutomations : MonoBehaviour {
        public AutomationPanelObjects automationPanelObjects;
        public List<Conditions> conditions = new List<Conditions>();
        public List<Effects> effectObjects = new List<Effects>();
        public TMP_Text NotificationText;
        public GameObject Notification;
        public string name;
        public AudioClip Audio1;
        public AudioClip Audio2;
        public AudioClip Audio3;
        public AudioClip Audio4;
        public SaveAutomation saveAutomation;

        public IEnumerator checkConditions(){
            foreach(Conditions condition in conditions){
                while(!condition.conditionMet){
                    yield return null;
                }
                // if(saveAutomation.not != null){
                //     StopCoroutine(saveAutomation.not);
                //     saveAutomation.not = null;
                // }
                NotificationText.text = name + " executed!";
                Notification.SetActive(true);
                try{
                    foreach(Effects effect in effectObjects){
                        SetEffect(effect);
                    }
                } catch {}
                yield return new WaitForSeconds(5);
                Notification.SetActive(false);
            }
            yield return null;
        }

        public IEnumerator CloseNotification(){
            yield return new WaitForSeconds(5);
            Notification.SetActive(false);
            saveAutomation.not = null;
        }

        private void SetEffect(Effects effects){
            switch(effects.typ){
                case "Light(Clone)":
                    if(effects.thirdObject.Equals("Lamp(Clone)")){ //ON
                        effects.conditionObject.GetComponentInChildren<Light>().enabled = true;
                        gameObject.GetComponentInChildren<LightHelper>().enabledUsedMethod();
                    } else if(effects.thirdObject.Equals("Lamp 1(Clone)")){ //OFF
                        effects.conditionObject.GetComponentInChildren<Light>().enabled = false;
                        gameObject.GetComponentInChildren<LightHelper>().enabledUsedMethod();
                    } else if(effects.thirdObject.Equals("LampColor(Clone)")){ //COLOR
                        string[] color = effects.argument.Split('|');
                        effects.conditionObject.GetComponentInChildren<LightHelper>().colorChanged(float.Parse(color[0]), float.Parse(color[1]), float.Parse(color[2]));
                    } else if(effects.thirdObject.Equals("LampIntensity(Clone)")){ //INTENSITY
                        effects.conditionObject.GetComponentInChildren<LightHelper>().intensityChanged(float.Parse(effects.argument));
                    }
                    break;
                case "Blind(Clone)":
                    if(effects.thirdObject.Equals("Blind(Clone)")){ //UP
                        effects.conditionObject.GetComponent<BlindController>().ChangeBlinds(0);
                        // StartCoroutine(ControlBlind(effects, 0));
                    } else if(effects.thirdObject.Equals("Blind 1(Clone)")){ //DOWN
                        effects.conditionObject.GetComponent<BlindController>().ChangeBlinds(-1);
                        // StartCoroutine(ControlBlind(effects, float.Parse(effects.argument)));
                    }
                    break;
                case "Speaker(Clone)":
                    var a = FindObjectsOfType<ControlSystemHelper>();
                    if(effects.thirdObject.Equals("Speaker(Clone)")){ //ON
                        effects.conditionObject.GetComponent<AudioSource>().Play();
                        gameObject.GetComponent<SpeakerHelper>().playpauseUsedMethod();
                        foreach(var b in a){
                            b.AudioOn("Playing");
                        }
                    } else if(effects.thirdObject.Equals("Speaker 1(Clone)")){ //OFF
                        effects.conditionObject.GetComponent<AudioSource>().Stop();
                        gameObject.GetComponent<SpeakerHelper>().playpauseUsedMethod();
                        foreach(var b in a){
                            b.AudioOn("Stopped");
                        }
                    } else if(effects.thirdObject.Equals("SpeakerAudio(Clone)")){ //VOLUME
                        effects.conditionObject.GetComponent<AudioSource>().clip = null;
                        switch (int.Parse(effects.argument))
                        {
                            case 0:
                                gameObject.GetComponent<AudioSource>().clip = Audio1;
                                foreach(var b in a){
                                    b.AudioChanged("Audio 1");
                                }
                                break;
                            case 1:
                                gameObject.GetComponent<AudioSource>().clip = Audio2;
                                foreach(var b in a){
                                    b.AudioChanged("Audio 2");
                                }
                                break;
                            case 2:
                                gameObject.GetComponent<AudioSource>().clip = Audio3;
                                foreach(var b in a){
                                    b.AudioChanged("Audio 3");
                                }
                                break;
                            case 3:
                                gameObject.GetComponent<AudioSource>().clip = Audio4;
                                foreach(var b in a){
                                    b.AudioChanged("Audio 4");
                                }
                                break;
                            default:
                                gameObject.GetComponent<AudioSource>().clip = null;
                                break;
                        }
                    }
                    break;
                case "AirConditioner(Clone)":
                    if(effects.thirdObject.Equals("AirConditioner(Clone)")){ //ON
                        effects.conditionObject.GetComponent<PlayConditioner>().StartAudio();
                        effects.conditionObject.transform.Find("AirFlow").gameObject.SetActive(true);
                        effects.conditionObject.transform.Find("AirFlow1").gameObject.SetActive(true);
                        effects.conditionObject.GetComponent<Animator>().SetBool("Close", false);
                        effects.conditionObject.GetComponent<Animator>().SetBool("Open", true);
                    } else if(effects.thirdObject.Equals("AirConditioner 1(Clone)")){ //OFF
                        effects.conditionObject.GetComponent<PlayConditioner>().EndAudio();
                        effects.conditionObject.transform.Find("AirFlow").gameObject.SetActive(false);
                        effects.conditionObject.transform.Find("AirFlow1").gameObject.SetActive(false);
                        effects.conditionObject.GetComponent<Animator>().SetBool("Close", true);
                        effects.conditionObject.GetComponent<Animator>().SetBool("Open", false);
                    }
                    break;
                case "AirPurifier(Clone)":
                    if(effects.thirdObject.Equals("AirPurifier(Clone)")){ //ON
                        effects.conditionObject.GetComponent<PlayConditioner>().StartAudio();
                        effects.conditionObject.GetComponent<AirPurifierHelper>().ActivateShader(true);
                    } else if(effects.thirdObject.Equals("AirPurifier 1(Clone)")){ //OFF
                        effects.conditionObject.GetComponent<PlayConditioner>().EndAudio();
                        effects.conditionObject.GetComponent<AirPurifierHelper>().DeactivateShader();
                    } else if(effects.thirdObject.Equals("AirPurifier 2(Clone)")){ //Cooling
                        effects.conditionObject.GetComponent<AirPurifierHelper>().cooling = true;
                        effects.conditionObject.GetComponent<AirPurifierHelper>().heating = false;
                    } else if(effects.thirdObject.Equals("AirPurifier 3(Clone)")){ //Warming
                        effects.conditionObject.GetComponent<AirPurifierHelper>().cooling = false;
                        effects.conditionObject.GetComponent<AirPurifierHelper>().heating = true;
                    }
                    break;
                case "TV(Clone)":
                    var a2 = FindObjectsOfType<ControlSystemHelper>();
                    if(effects.thirdObject.Equals("TV(Clone)")){ //ON
                        effects.conditionObject.transform.Find("Canvas").gameObject.SetActive(true);
                    } else if(effects.thirdObject.Equals("TV 1(Clone)")){ //OFF
                        effects.conditionObject.transform.Find("Canvas").gameObject.SetActive(false);
                    } else if(effects.thirdObject.Equals("TV 2(Clone)")){ //Play
                        // effects.conditionObject.GetComponent<VideoPlayer>().Play();
                        foreach(var b in a2){
                            b.TVOn("Playing");
                        }
                        effects.conditionObject.GetComponent<tvHelper>().PlayVideo();
                    } else if(effects.thirdObject.Equals("TV 3(Clone)")){ //Stop
                        // effects.conditionObject.GetComponent<VideoPlayer>().Stop();
                        foreach(var b in a2){
                            b.TVOn("Stopped");
                        }
                        effects.conditionObject.GetComponent<tvHelper>().StopVideo();
                    } else if(effects.thirdObject.Equals("TV 4(Clone)")){ //Audio Output
                        string name = effects.argument;
                        if(name == "TV"){
                            gameObject.GetComponent<VideoPlayer>().audioOutputMode = VideoAudioOutputMode.Direct;
                        } else {
                            SpawnedObject audio = ObjectSpawnerOwn.objekte.Find(t => t.name.Equals(name));
                            if(audio == null){
                                return;
                            }
                            effects.conditionObject.GetComponent<tvHelper>().audioSource = audio.gameObject.GetComponent<AudioSource>();
                            // gameObject.GetComponent<VideoPlayer>().audioOutputMode = VideoAudioOutputMode.AudioSource;
                            // gameObject.GetComponent<VideoPlayer>().SetTargetAudioSource(0, audio.gameObject.GetComponent<AudioSource>());
                        }
                    }
                    break;
                case "Coffee(Clone)":
                    if(effects.thirdObject.Equals("Coffee(Clone)")){ //ON
                        effects.conditionObject.GetComponent<CoffeeHelper>().BtnClicked();
                    } else {
                        effects.conditionObject.GetComponent<CoffeeHelper>().RestClicked();
                    }
                    break;
            }
        }
    }

    public class Conditions{
        public string conditionObject;
        public bool conditionMet;

        public Conditions(string name, bool met){
            conditionObject = name;
            conditionMet = met;
        }
    }
    
    public class Effects{
        public GameObject conditionObject;
        public string secondObject;
        public string thirdObject;

        public string typ;

        public string argument;
    }
}
