using System.Collections;
using System.Collections.Generic;
using scripst;
using scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutomationManager : MonoBehaviour
{

    //[SerializeField]
    private GameObject PanelTransform;
    //[SerializeField]
    private VirtualLayoutOwn virtualLayout;

    [SerializeField]
    public GameObject AndField;
    [SerializeField]
    public GameObject ThenField;
    [SerializeField]
    public GameObject WhenField;
    [SerializeField]
    public GameObject AddDevice;
    [SerializeField]
    public GameObject AddCondition;
    [SerializeField]
    public GameObject AddDeviceEff;
    [SerializeField]
    public GameObject AddEffect;


    //[SerializeField]
    public GameObject LibraryPage;

    //[SerializeField]
    public GameObject ListAddDevice;
    //[SerializeField]
    public GameObject ListAddDeviceVisual;
    //[SerializeField]
    public GameObject ListAddCond;
    //[SerializeField]
    public GameObject ListAddCondVisual;
    //[SerializeField]
    public GameObject ListAddDeviceEff;
    //[SerializeField]
    public GameObject ListAddDeviceEffVisual;
    //[SerializeField]
    public GameObject ListAddEffect;
    //[SerializeField]
    public GameObject ListAddEffectVisual;

    [SerializeField]
    public GameObject AddBlock;

    [SerializeField]
    public GameObject DeviceBlock;

    [SerializeField]
    public AutomationDeaktivieren automationDeaktivieren;

    private AutomationPanelObjects Reihen;


    [SerializeField]
    public bool testCond;
    [SerializeField]
    public bool testEff;
    [SerializeField]
    public bool testDev;
    [SerializeField]
    public bool testCo;
    [SerializeField]
    public bool testDevEff;
    [SerializeField]
    public bool testTestBtn;
    private void Start()
    {
        //GameObject when = Instantiate(WhenField, PanelTransform.transform);
        //GameObject addD = Instantiate(AddDevice, PanelTransform.transform);
        //GameObject addC = Instantiate(AddCondition, PanelTransform.transform);
        //Reihen.Add(new ReiheAutomation(when, addD, addC, ReihenTyp.CONDITION) { ConditionHinzugefügt = true, DeviceHinzugefügt = true  });
        //CurrentCon++;
        //GameObject a = Instantiate(WhenField, PanelTransform.transform);
        //GameObject b = Instantiate(AddDevice, PanelTransform.transform);
        //GameObject c = Instantiate(AddCondition, PanelTransform.transform);
        //Reihen.Add(new ReiheAutomation(a, b, c, ReihenTyp.CONDITION));
        //CurrentCon++;
        //PanelTransform.SetActive(false);
        //PanelTransform.SetActive(true);
    }

    private void Update()
    {
        if (testCond)
        {
            //Destroy(Reihen[0].third);
            //AddConditionRow();
            //AddEffectRow();

            //AddDeviceFunc(AndField, null);
            AddConditionRow();
            testCond = false;
        }
        if (testEff)
        {
            AddEffectRow();
            testEff = false;
        }
        if (testDev)
        {
            AddDeviceFunc(DeviceBlock, "Test", null);
            testDev = false;
        }
        if (testCo)
        {
            AddConditionFunc(DeviceBlock, null, "Test");
            testCo = false;
        }
        if (testDevEff)
        {
            testDevEff = false;
            LibraryPage.SetActive(false);
            ListAddDevice.GetComponent<AddDeviceSelection>().DeleteSelection();
            ListAddDevice.GetComponent<AddDeviceSelection>().AddSelection();
            ListAddDevice.SetActive(true);
        }
        if(testTestBtn)
        {
            // BloeckeAnpassen();
            testTestBtn = false;
            GameObject go = GameObject.FindGameObjectWithTag("test");
            go.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void UpdateAutomation(AutomationPanelObjects gameObject)
    {
        Reihen = gameObject;
        LibraryPage = gameObject.gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/Library Page 1").gameObject;
        ListAddDevice = gameObject.gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/AddDevice").gameObject;
        ListAddDeviceVisual = ListAddDevice.transform.Find("Viewport/Padding/Visuals").gameObject;
        ListAddCond = gameObject.gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/AddCond").gameObject;
        ListAddCondVisual = ListAddCond.transform.Find("Viewport/Padding/Visuals").gameObject;
        ListAddDeviceEff = gameObject.gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/AddDeviceEff").gameObject;
        ListAddDeviceEffVisual = ListAddDeviceEff.transform.Find("Viewport/Padding/Visuals").gameObject;
        ListAddEffect = gameObject.gameObject.transform.Find("MenuContentLeftMargin/HorizontalPageScroll/AddEffect").gameObject;
        ListAddEffectVisual = ListAddEffect.transform.Find("Viewport/Padding/Visuals").gameObject;
        PanelTransform = LibraryPage.transform.Find("Viewport/Padding/Visuals").gameObject;
        virtualLayout = PanelTransform.GetComponent<VirtualLayoutOwn>();
        // BloeckeAnpassen();
    }

    public static TypVonObject aktTypCond = TypVonObject.NONE;

    public void AddConditionRow()
    {
        if(Reihen == null)
        {
            return;
        }
        ReiheAutomation last = Reihen.Reihen.FindLast(t => t.ReihenTyp.Equals(ReihenTyp.CONDITION));
        if (last != null && ( !last.DeviceHinzugefügt || !last.ConditionHinzugefügt))
        {
            return;
        }
        GameObject first = null;
        if(Reihen.Reihen.Count > 0)
        {
            first = Instantiate(AndField, PanelTransform.transform);
        } else
        {
            first = Instantiate(WhenField, PanelTransform.transform);
        }
        GameObject addD = Instantiate(AddDevice, PanelTransform.transform);
        addD.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(ObjectSpawnerOwn.objekte.Count == 0)
            {
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddDevice.GetComponent<AddDeviceSelection>().DeleteSelection();
            ListAddDevice.GetComponent<AddDeviceSelection>().AddSelection();
            ListAddDevice.SetActive(true);
        });
        GameObject addC = Instantiate(AddCondition, PanelTransform.transform);
        addC.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(aktTypCond == TypVonObject.NONE){
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddCond.GetComponent<AddConditionSelection>().DeleteSelection();
            ListAddCond.GetComponent<AddConditionSelection>().AddOptions(aktTypCond);
            ListAddCond.SetActive(true);
        });
        addC.GetComponentInChildren<Button>().interactable = false;
        if (Reihen.CurrentEff == -1)
        {
            Reihen.Reihen.Add(new ReiheAutomation(first, addD, addC, ReihenTyp.CONDITION));
        }
        else
        {
            Reihen.Reihen.Insert(Reihen.CurrentCon + 1, new ReiheAutomation(first, addD, addC, ReihenTyp.CONDITION));
            int insertIndex = 3;
            if(!(Reihen.CurrentCon == 0))
            {
                insertIndex = (Reihen.CurrentCon * 3) + 3;
            }
            first.transform.SetSiblingIndex(insertIndex);
            addD.transform.SetSiblingIndex(insertIndex + 1);
            addC.transform.SetSiblingIndex(insertIndex + 2);
        }
        Reihen.CurrentCon++;
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
    }

    public static TypVonObject aktTypEff = TypVonObject.NONE;

    public void AddEffectRow()
    {
        if(Reihen == null)
        {
            return;
        }
        ReiheAutomation last = Reihen.Reihen.FindLast(t => t.ReihenTyp.Equals(ReihenTyp.EFFECT));
        if (last != null && ( !last.DeviceHinzugefügt || !last.ConditionHinzugefügt))
        {
            return;
        }
        GameObject first = Instantiate(ThenField, PanelTransform.transform);
        GameObject second = Instantiate(AddDevice, PanelTransform.transform);
        second.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(ObjectSpawnerOwn.objekte.Count == 0)
            {
                return;
            }   
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddDeviceEff.GetComponent<AddDeviceSelectionEffect>().DeleteSelection();
            ListAddDeviceEff.GetComponent<AddDeviceSelectionEffect>().AddSelection();
            ListAddDeviceEff.SetActive(true);
        });
        GameObject third = Instantiate(AddEffect, PanelTransform.transform);
        third.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(aktTypEff == TypVonObject.NONE){
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddEffect.GetComponent<AddEffectSelection>().DeleteSelection();
            ListAddEffect.GetComponent<AddEffectSelection>().AddOptions(aktTypEff);
            ListAddEffect.SetActive(true);
        });
        third.GetComponentInChildren<Button>().interactable = false;
        Reihen.Reihen.Add(new ReiheAutomation(first, second, third, ReihenTyp.EFFECT));
        Reihen.CurrentEff++;
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
    }

    public void AddDeviceFunc(GameObject Device, string name, GameObject gameObject, int? ReihenCurrentCon = null)
    {
        int deleteIndex;
        if(ReihenCurrentCon == null){
            deleteIndex = Reihen.CurrentCon;
        } else {
            deleteIndex = (int)ReihenCurrentCon;
        }
        Destroy(Reihen.Reihen[deleteIndex].second);
        GameObject newObj = Instantiate(Device, PanelTransform.transform);
        if(name != null)
        {
            newObj.GetComponentInChildren<TMP_Text>().text = name;
        }
        int insertIndex = 1;
        if (!(Reihen.CurrentCon == 0))
        {
            insertIndex = (Reihen.CurrentCon * 3) + 1;
        }
        if(ReihenCurrentCon != null){
            insertIndex = ((int)ReihenCurrentCon * 3) + 1;
        }
        newObj.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(ObjectSpawnerOwn.objekte.Count == 0)
            {
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddDevice.GetComponent<AddDeviceSelection>().DeleteSelection();
            ListAddDevice.GetComponent<AddDeviceSelection>().AddSelection(ReihenCurrentCon ?? Reihen.CurrentCon);
            ListAddDevice.SetActive(true);
        });
        virtualLayout.RemoveChildAtIndex(insertIndex);
        newObj.transform.SetSiblingIndex(insertIndex);
        Reihen.Reihen[deleteIndex].DeviceHinzugefügt = true;
        Reihen.Reihen[deleteIndex].secondObject = name;
        Reihen.Reihen[deleteIndex].second = newObj;
        if(ReihenCurrentCon != null){
            PanelTransform.SetActive(false);
            PanelTransform.SetActive(true);
            Destroy(Reihen.Reihen[deleteIndex].third);
            GameObject newObjThird = Instantiate(AddCondition, PanelTransform.transform);
            newObjThird.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                if(aktTypCond == TypVonObject.NONE){
                    return;
                }
                automationDeaktivieren.Deaktivieren();
                LibraryPage.SetActive(false);
                ListAddCond.GetComponent<AddConditionSelection>().DeleteSelection();
                ListAddCond.GetComponent<AddConditionSelection>().AddOptions(aktTypCond, ReihenCurrentCon);
                ListAddCond.SetActive(true);
            });
            virtualLayout.RemoveChildAtIndex(insertIndex + 1);
            newObjThird.transform.SetSiblingIndex(insertIndex + 1);
            Reihen.Reihen[deleteIndex].third = newObjThird;
            Reihen.Reihen[deleteIndex].ConditionHinzugefügt = false;
        }
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
        // CondEffAnpassen();
            Reihen.Reihen[deleteIndex].third.GetComponentInChildren<Button>().interactable = true;
        automationDeaktivieren.Aktivieren();
    }

    public void AddConditionFunc(GameObject Cond, GameObject gameObject, string name = null, int? ReihenCurrentCon = null, TypVonObject typ = TypVonObject.NONE)
    {
        int deleteIndex;
        if(ReihenCurrentCon == null){
            deleteIndex = Reihen.CurrentCon;
        } else {
            deleteIndex = (int)ReihenCurrentCon;
        }
        Destroy(Reihen.Reihen[deleteIndex].third);
        GameObject newObj = Instantiate(Cond, PanelTransform.transform);
        if (name != null)
        {
            newObj.GetComponentInChildren<TMP_Text>().text = name;
        }
        int insertIndex = 2;
        if (!(Reihen.CurrentCon == 0))
        {
            insertIndex = (Reihen.CurrentCon * 3) + 2;
        }
        if(ReihenCurrentCon != null){
            insertIndex = ((int)ReihenCurrentCon * 3) + 2;
        }
        newObj.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(typ == TypVonObject.NONE){
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddCond.GetComponent<AddConditionSelection>().DeleteSelection();
            ListAddCond.GetComponent<AddConditionSelection>().AddOptions(typ, ReihenCurrentCon);
            ListAddCond.SetActive(true);
        });
        virtualLayout.RemoveChildAtIndex(insertIndex);
        newObj.transform.SetSiblingIndex(insertIndex);
        Reihen.Reihen[deleteIndex].ConditionHinzugefügt = true;
        Reihen.Reihen[deleteIndex].thirdObject = newObj.name;
        Reihen.Reihen[deleteIndex].third = newObj;
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
        automationDeaktivieren.Aktivieren();
    }

    public void AddDeviceEffFunc(GameObject DeviceEff, string name, GameObject gameObject, int? ReihenCurrentEff = null)
    {
        int deleteIndex;
        if(ReihenCurrentEff == null){
            deleteIndex = Reihen.CurrentCon + Reihen.CurrentEff + 1;
        } else {
            deleteIndex = Reihen.CurrentCon + (int)ReihenCurrentEff + 1;
        }
        Destroy(Reihen.Reihen[deleteIndex].second);
        GameObject newObj = Instantiate(DeviceEff, PanelTransform.transform);
        if (name != null)
        {
            newObj.GetComponentInChildren<TMP_Text>().text = name;
        }
        int insertIndex = 4;
        if (Reihen.CurrentCon != 0 || Reihen.CurrentEff != 0)
        {
            if(Reihen.CurrentCon != 0 && Reihen.CurrentEff == 0)
            {
                insertIndex = (Reihen.CurrentCon * 3) + 4;
            } else if(Reihen.CurrentEff != 0 && Reihen.CurrentCon == 0)
            {
                insertIndex = (Reihen.CurrentEff * 3) + 4;
            } else 
            {
                insertIndex = (Reihen.CurrentCon * 3) + (Reihen.CurrentEff * 3) + 4;
            }
        }
        if(ReihenCurrentEff != null){
            if(Reihen.CurrentCon != 0 && ReihenCurrentEff == 0)
            {
                insertIndex = (Reihen.CurrentCon * 3) + 4;
            } else if(ReihenCurrentEff != 0 && Reihen.CurrentCon == 0)
            {
                insertIndex = ((int)ReihenCurrentEff * 3) + 4;
            } else 
            {
                insertIndex = (Reihen.CurrentCon * 3) + ((int)ReihenCurrentEff * 3) + 4;
            }
        }
        newObj.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            if(ObjectSpawnerOwn.objekte.Count == 0)
            {
                return;
            }
            automationDeaktivieren.Deaktivieren();
            LibraryPage.SetActive(false);
            ListAddDeviceEff.GetComponent<AddDeviceSelectionEffect>().DeleteSelection();
            ListAddDeviceEff.GetComponent<AddDeviceSelectionEffect>().AddSelection(ReihenCurrentEff ?? Reihen.CurrentEff);
            ListAddDeviceEff.SetActive(true);
        });
        Reihen.Reihen[deleteIndex].DeviceHinzugefügt = true;
        Reihen.Reihen[deleteIndex].secondObject = name;
        Reihen.Reihen[deleteIndex].second = newObj;
        try{
            virtualLayout.RemoveChildAtIndex(insertIndex);
        } catch (System.Exception e)
        {
            Debug.Log(e);
            return;
        }

        newObj.transform.SetSiblingIndex(insertIndex);
        if(ReihenCurrentEff != null){
            PanelTransform.SetActive(false);
            PanelTransform.SetActive(true);
            Destroy(Reihen.Reihen[deleteIndex].third);
            GameObject newObjThird = Instantiate(AddEffect, PanelTransform.transform);
            newObjThird.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                if(aktTypEff == TypVonObject.NONE){
                    return;
                }
                automationDeaktivieren.Deaktivieren();
                LibraryPage.SetActive(false);
                ListAddEffect.GetComponent<AddEffectSelection>().DeleteSelection();
                ListAddEffect.GetComponent<AddEffectSelection>().AddOptions(aktTypEff, ReihenCurrentEff);
                ListAddEffect.SetActive(true);
            });
            virtualLayout.RemoveChildAtIndex(insertIndex + 1);
            newObjThird.transform.SetSiblingIndex(insertIndex + 1);
            Reihen.Reihen[deleteIndex].third = newObjThird;
            Reihen.Reihen[deleteIndex].ConditionHinzugefügt = false;
        }
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
        Reihen.Reihen[deleteIndex].third.GetComponentInChildren<Button>().interactable = true;
        automationDeaktivieren.Aktivieren();
    }

    [SerializeField]
    public GameObject lampObj;

    [SerializeField]
    public GameObject lampIntObj;
    [SerializeField]
    public GameObject speakerObj;
    [SerializeField]
    public GameObject tvObj;
    public void AddEffectFunc(GameObject Effect, GameObject gameObject, string name = null, bool lampe = false, bool lampeInt = false, bool speaker = false, bool tv = false, int? ReihenCurrentEff = null, TypVonObject typ = TypVonObject.NONE)
    {
        int dIndex;
        if(ReihenCurrentEff == null){
            dIndex = Reihen.CurrentCon + Reihen.CurrentEff + 1;
        } else {
            dIndex = Reihen.CurrentCon + (int)ReihenCurrentEff + 1;
        }
        Destroy(Reihen.Reihen[dIndex].third);
        GameObject newObj = null;
        if(lampe){
            newObj = Instantiate(lampObj, PanelTransform.transform);
        } else if(lampeInt){
            newObj = Instantiate(lampIntObj, PanelTransform.transform);
        } else if(speaker){
            newObj = Instantiate(speakerObj, PanelTransform.transform);
        } else if(tv){
            newObj = Instantiate(tvObj, PanelTransform.transform);
        } else {
            newObj = Instantiate(Effect, PanelTransform.transform);
        }
        if (name != null)
        {
            newObj.GetComponentInChildren<TMP_Text>().text = name;
        }
        int insertIndex = 5;
        if (Reihen.CurrentCon != 0 || Reihen.CurrentEff != 0)
        {
            if (Reihen.CurrentCon != 0 && Reihen.CurrentEff == 0)
            {
                insertIndex = (Reihen.CurrentCon * 3) + 5;
            }
            else if (Reihen.CurrentEff != 0 && Reihen.CurrentCon == 0)
            {
                insertIndex = (Reihen.CurrentEff * 3) + 5;
            }
            else
            {
                insertIndex = (Reihen.CurrentCon * 3) + (Reihen.CurrentEff * 3) + 5;
            }
        }
        if(ReihenCurrentEff != null){
            if (Reihen.CurrentCon != 0 && ReihenCurrentEff == 0)
            {
                insertIndex = (Reihen.CurrentCon * 3) + 5;
            }
            else if (ReihenCurrentEff != 0 && Reihen.CurrentCon == 0)
            {
                insertIndex = ((int)ReihenCurrentEff * 3) + 5;
            }
            else
            {
                insertIndex = (Reihen.CurrentCon * 3) + ((int)ReihenCurrentEff * 3) + 5;
            }
        }
        if(tv){
            newObj.transform.Find("Content/Background/Change").gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                if(typ == TypVonObject.NONE){
                    return;
                }
                automationDeaktivieren.Deaktivieren();
                LibraryPage.SetActive(false);
                ListAddEffect.GetComponent<AddEffectSelection>().DeleteSelection();
                ListAddEffect.GetComponent<AddEffectSelection>().AddOptions(typ, ReihenCurrentEff ?? Reihen.CurrentEff);
                ListAddEffect.SetActive(true);
            });
        } else {
            newObj.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                if(typ == TypVonObject.NONE){
                    return;
                }
                automationDeaktivieren.Deaktivieren();
                LibraryPage.SetActive(false);
                ListAddEffect.GetComponent<AddEffectSelection>().DeleteSelection();
                ListAddEffect.GetComponent<AddEffectSelection>().AddOptions(typ, ReihenCurrentEff ?? Reihen.CurrentEff);
                ListAddEffect.SetActive(true);
            });
        }
        Reihen.Reihen[dIndex].ConditionHinzugefügt = true;
        virtualLayout.RemoveChildAtIndex(insertIndex);
        newObj.transform.SetSiblingIndex(insertIndex);
        Reihen.Reihen[dIndex].thirdObject = newObj.name;
        Reihen.Reihen[dIndex].third = newObj;
        PanelTransform.SetActive(false);
        PanelTransform.SetActive(true);
        automationDeaktivieren.Aktivieren();
    }

    public void BloeckeAnpassen()
    {
        for (int i = ListAddDeviceVisual.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(ListAddDeviceVisual.transform.GetChild(i).gameObject);
        }
        for (int i = ListAddDeviceEffVisual.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(ListAddDeviceEffVisual.transform.GetChild(i).gameObject);
        }
        foreach (SpawnedObject g in ObjectSpawnerOwn.objekte)
        {
            GameObject newObjDevice = null;
            GameObject newObjDeviceEff = null;
            switch (g.objectType)
            {
                case TypVonObject.LAMP:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
                case TypVonObject.AIRPURIFIER:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
                case TypVonObject.AIRSENSOR:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
                case TypVonObject.BLIND:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
                case TypVonObject.CONTROLSYSTEM:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
                case TypVonObject.SPEAKER:
                    newObjDevice = Instantiate(AddBlock, ListAddDeviceVisual.transform);
                    newObjDeviceEff = Instantiate(AddBlock, ListAddDeviceEffVisual.transform);
                    break;
            }
            newObjDevice.GetComponentInChildren<TMP_Text>().text = g.name;
            newObjDeviceEff.GetComponentInChildren<TMP_Text>().text = g.name;
            newObjDevice.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                AddDeviceFunc(DeviceBlock, g.name, null);
                ListAddDevice.SetActive(false);
                LibraryPage.SetActive(true);
            });
            newObjDeviceEff.GetComponentInChildren<Button>().onClick.AddListener(delegate
            {
                AddDeviceEffFunc(DeviceBlock, g.name, null);
                ListAddDeviceEff.SetActive(false);
                LibraryPage.SetActive(true);
            });
        }
    }

    public void CondEffAnpassen()
    {
        for (int i = ListAddCondVisual.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(ListAddCondVisual.transform.GetChild(i).gameObject);
        }
        for (int i = ListAddEffectVisual.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(ListAddEffectVisual.transform.GetChild(i).gameObject);
        }
        GameObject newObjCond = null;
        GameObject newObjEff = null;
        newObjCond = Instantiate(AddBlock, ListAddCondVisual.transform);
        newObjEff = Instantiate(AddBlock, ListAddEffectVisual.transform);
        newObjCond.GetComponentInChildren<TMP_Text>().text = "Test";
        newObjEff.GetComponentInChildren<TMP_Text>().text = "Test";
        newObjCond.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            AddConditionFunc(DeviceBlock, null, "Test");
            ListAddCond.SetActive(false);
            LibraryPage.SetActive(true);
        });
        newObjEff.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            AddEffectFunc(DeviceBlock, null, "Test");
            ListAddEffect.SetActive(false);
            LibraryPage.SetActive(true);
        });
    }
}

public class ReiheAutomation
{
    public ReihenTyp ReihenTyp;

    public GameObject first { get; set; }
    public GameObject second { get; set; }
    public string secondObject { get; set; }
    public GameObject third { get; set; }
    public string thirdObject { get; set; }

    public bool DeviceHinzugefügt = false;
    public bool ConditionHinzugefügt = false;

    public ReiheAutomation(GameObject _first, GameObject _second, GameObject _third, ReihenTyp _typ)
    {
        first = _first;
        second = _second;
        third = _third;
        ReihenTyp = _typ;

#if DEBUG
        //DeviceHinzugefügt = true;
        //ConditionHinzugefügt = true;
#endif
    }
}

public enum ReihenTyp
{
    CONDITION,
    EFFECT
}
