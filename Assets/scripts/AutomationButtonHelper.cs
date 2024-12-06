using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomationButtonHelper : MonoBehaviour
{

    [SerializeField] public GameObject SeitenBarAutomation;
    [SerializeField] public AutomationManagerBottom amBottom;
    // Start is called before the first frame update
    public void AutomationActive(){
        if(AutomationManagerBottom.AutomationPanels.Count > 0 && SeitenBarAutomation != null){
            SeitenBarAutomation.SetActive(true);
            AutomationManagerBottom.AutomationPanels[AutomationManagerBottom.currentActiveIndex].gameObject.SetActive(true);
        }
    }

    public void MainMenuActive(){
        if(AutomationManagerBottom.AutomationPanels.Count > 0 && SeitenBarAutomation != null){
            SeitenBarAutomation.SetActive(false);
            AutomationManagerBottom.AutomationPanels[AutomationManagerBottom.currentActiveIndex].gameObject.SetActive(false);
        }
    }
}
