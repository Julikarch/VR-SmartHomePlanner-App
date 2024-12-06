using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutomationManagerBottom : MonoBehaviour
{
    [SerializeField]
    public GameObject AutomationPanel;
    [SerializeField]
    public GameObject AutomationPanelParent;
    [SerializeField]
    public GameObject AutomationPanelAddPanel;
    [SerializeField]
    public AutomationManager AutomationManager;
    [SerializeField]
    public GameObject AddAutomationButton;
    [SerializeField]
    public GameObject AddAutomationButtonParent;
    [SerializeField]
    public AutomationDeaktivieren AutomationDeaktivieren;
    [SerializeField]
    public static AutomationDeaktivieren AutomationEntfernen;
    [SerializeField]
    public Button buttonDelete;


    [SerializeField]
    public bool test = false;
    [SerializeField]
    public bool test1 = false;
    [SerializeField]
    public bool test2 = false;
    [SerializeField]
    public bool test3 = false;
    [SerializeField]
    public bool test4 = false;

    public static List<AutomationPanelObjects> AutomationPanels = new List<AutomationPanelObjects>();
    public static  int currentActiveIndex = -1;

    void Start()
    {
        //GameObject newObj = Instantiate(AutomationPanel, AutomationPanelParent.transform);
        //AutomationPanels.Add(newObj);
        //currentActiveIndex = AutomationPanels.IndexOf(newObj);
        //AutomationManager.UpdateAutomation(newObj);
        //AddAutomation();
    }

    private void Update()
    {
        if (test)
        {
            AddAutomation();
            test = false;
        }
        if (test1)
        {
            ChangeActiveAutomation(0);
            test1 = false;
        }
        if (test2)
        {
            ChangeActiveAutomation(1);
            test2 = false;
        }
        if (test3)
        {
            ChangeActiveAutomation(2);
            test3 = false;
        }
        if (test4)
        {
            ChangeActiveAutomation(3);
            test4 = false;
        }
    }

    public void AddAutomation()
    {
        AutomationPanelAddPanel.SetActive(true);
        buttonDelete.interactable = true;
        GameObject newObj = Instantiate(AutomationPanel, AutomationPanelParent.transform);
        AutomationPanelObjects newAut = new AutomationPanelObjects(newObj);
        AutomationPanels.Insert(0, newAut);
        if(currentActiveIndex != -1)
        {
            AutomationPanels[currentActiveIndex+1].gameObject.SetActive(false);
            AutomationPanels[currentActiveIndex+1].gameObjectButton.GetComponent<Image>().color = Color.white;
            AutomationPanels[currentActiveIndex+1].gameObjectButton.GetComponentInChildren<TMP_Text>().color = Color.black;
        }
        currentActiveIndex = AutomationPanels.IndexOf(newAut);
        AutomationManager.UpdateAutomation(newAut);
        GameObject newObjBtn = Instantiate(AddAutomationButton, AddAutomationButtonParent.transform);
        AutomationPanels[currentActiveIndex].gameObjectButton = newObjBtn;
        AutomationPanels[currentActiveIndex].gameObjectButton.GetComponent<Image>().color = new Color(188/255, 164/255, 255/255);
        AutomationPanels[currentActiveIndex].gameObjectButton.GetComponentInChildren<TMP_Text>().color = Color.white;
        newObjBtn.transform.SetSiblingIndex(0);
        newObjBtn.GetComponentInChildren<TMP_Text>().text = "Automation" + AutomationPanels.Count;
        AutomationPanels[currentActiveIndex].name = newObjBtn.GetComponentInChildren<TMP_Text>().text;
        newObjBtn.GetComponentInChildren<Button>().onClick.AddListener(delegate
        {
            ChangeActiveAutomation(newObjBtn.transform.GetSiblingIndex());
        });
        AutomationDeaktivieren.deaktivieren.AddListener(delegate
        {
            if(newObjBtn != null){
                newObjBtn.GetComponentInChildren<Button>().interactable = false;
            }
        });
        AutomationDeaktivieren.aktivieren.AddListener(delegate
        {
            if(newObjBtn != null){
                newObjBtn.GetComponentInChildren<Button>().interactable = true;
            }
        });
    }

    public void AktuelleAutmationEntfernen()
    {
        DeleteAutomation(AutomationPanels[currentActiveIndex]);
    }

    public void DeleteAutomation(AutomationPanelObjects automationPanelObjects)
    {
        if (AutomationPanels.Count > 1)
        {
            foreach(var test in SaveAutomation.savedAutomations){
                if(test.name == automationPanelObjects.name){
                    SaveAutomation.savedAutomations.Remove(test);
                    test.StopAllCoroutines();
                    test.conditions.Clear();
                    test.effectObjects.Clear();
                    break;
                }
            }
            bool changeToZero = false;
            if (currentActiveIndex == AutomationPanels.IndexOf(automationPanelObjects))
            {
                if(currentActiveIndex == 0){
                    ChangeActiveAutomation(1);
                    changeToZero = true;
                } else {
                    ChangeActiveAutomation(0);
                }
            }
            else if (currentActiveIndex > AutomationPanels.IndexOf(automationPanelObjects))
            {
                currentActiveIndex--;
            }
            AutomationPanels.Remove(automationPanelObjects);
            Destroy(automationPanelObjects.gameObject);
            Destroy(automationPanelObjects.gameObjectButton);
            if(changeToZero){
                currentActiveIndex = 0;
            }
        } else {
            foreach(var test in SaveAutomation.savedAutomations){
                if(test.name == automationPanelObjects.name){
                    SaveAutomation.savedAutomations.Remove(test);
                    test.StopAllCoroutines();
                    test.conditions.Clear();
                    test.effectObjects.Clear();
                    break;
                }
            }
            Destroy(automationPanelObjects.gameObject);
            Destroy(automationPanelObjects.gameObjectButton);
            AutomationPanels.Remove(automationPanelObjects);
            buttonDelete.interactable = false;
            AutomationPanelAddPanel.SetActive(false);
            currentActiveIndex = -1;
        }
    }

    public void ChangeActiveAutomation(int indexNew)
    {
        AutomationPanels[currentActiveIndex].gameObject.SetActive(false);
        AutomationPanels[currentActiveIndex].gameObjectButton.GetComponent<Image>().color = Color.white;
        AutomationPanels[currentActiveIndex].gameObjectButton.GetComponentInChildren<TMP_Text>().color = Color.black;
        AutomationPanels[indexNew].gameObject.SetActive(true);
        AutomationPanels[indexNew].gameObjectButton.GetComponent<Image>().color = new Color(188/255, 164/255, 255/255);
        AutomationPanels[indexNew].gameObjectButton.GetComponentInChildren<TMP_Text>().color = Color.white;
        currentActiveIndex = indexNew;
        AutomationManager.UpdateAutomation(AutomationPanels[indexNew]);
    }
}

public class AutomationPanelObjects
{
    public GameObject gameObject;
    public GameObject gameObjectButton;
    public List<ReiheAutomation> Reihen = new List<ReiheAutomation>();
    public string name;
    public int CurrentCon = -1;
    public int CurrentEff = -1;

    public AutomationPanelObjects(GameObject _gameObject)
    {
        gameObject = _gameObject;
    }
}
