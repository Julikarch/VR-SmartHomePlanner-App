using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainMenuTutorial;
    [SerializeField] private GameObject mainMenuTutorialTitle;
    [SerializeField] private GameObject[] mainMenuExample;
    [SerializeField] private GameObject[] mainMenuOverlay;
    [SerializeField] private GameObject automationMenu;
    [SerializeField] private GameObject automationMenuTutorial;
    [SerializeField] private GameObject automationMenuTutorialTitle;
    [SerializeField] private GameObject[] automationMenuExample;
    [SerializeField] private GameObject[] automationMenuOverlay;

    [SerializeField] private Transform player;
    [SerializeField] private float distance;

    private bool mainMenuTutorialShown = false;
    private int mainMenuTutorialStep = 0;
    private bool automationMenuTutorialShown = false;
    private int automationMenuTutorialStep = 0;

    public void ShowMainTutorial()
    {
        tutorial.transform.position = player.localPosition + Vector3.forward * distance * 2;
        mainMenuTutorialShown = true;
        mainMenuTutorialTitle.SetActive(true);  
        tutorial.SetActive(true);
        mainMenuTutorial.SetActive(true);
        mainMenuExample[0].SetActive(true);
        mainMenuOverlay[0].SetActive(true);
    }

    public void NextTutorial()
    {
        if (mainMenuTutorialShown && mainMenuTutorialStep < mainMenuExample.Length-1)
        {
            NextMainOverlay();
        } else if (automationMenuTutorialShown && automationMenuTutorialStep < automationMenuExample.Length-1)
        {
            NextAutomationOverlay();
        } else {
            CloseTutorial();
            if (mainMenuTutorialShown)
            {
                mainMenu.SetActive(true);
            } else if (automationMenuTutorialShown)
            {   
                automationMenu.SetActive(true);
            }
        }
    }

    public void PreviousTutorial()
    {
        if (mainMenuTutorialShown && mainMenuTutorialStep > 0)
        {
            mainMenuExample[mainMenuTutorialStep].SetActive(false);
            mainMenuOverlay[mainMenuTutorialStep].SetActive(false);
            mainMenuExample[mainMenuTutorialStep-1].SetActive(true);
            mainMenuOverlay[mainMenuTutorialStep-1].SetActive(true);
            mainMenuTutorialStep--;
        }
        else if (automationMenuTutorialShown && automationMenuTutorialStep > 0)
        {
            automationMenuExample[automationMenuTutorialStep].SetActive(false);
            automationMenuOverlay[automationMenuTutorialStep].SetActive(false);
            automationMenuExample[automationMenuTutorialStep-1].SetActive(true);
            automationMenuOverlay[automationMenuTutorialStep-1].SetActive(true);
            automationMenuTutorialStep--;
        }
    }

    private void NextMainOverlay()
    {
        mainMenuExample[mainMenuTutorialStep].SetActive(false);
        mainMenuOverlay[mainMenuTutorialStep].SetActive(false);
        mainMenuExample[mainMenuTutorialStep+1].SetActive(true);
        mainMenuOverlay[mainMenuTutorialStep+1].SetActive(true);
        mainMenuTutorialStep++;
    }

    public void ShowAutomationTutorial()
    {
        tutorial.transform.position = player.localPosition + Vector3.forward * distance * 2;
        automationMenuTutorialShown = true;
        tutorial.SetActive(true);
        automationMenuTutorial.SetActive(true);
        automationMenuTutorialTitle.SetActive(true);
        automationMenuExample[0].SetActive(true);
        automationMenuOverlay[0].SetActive(true);
    }

    private void NextAutomationOverlay()
    {
        automationMenuExample[automationMenuTutorialStep].SetActive(false);
        automationMenuOverlay[automationMenuTutorialStep].SetActive(false);
        automationMenuExample[automationMenuTutorialStep+1].SetActive(true);
        automationMenuOverlay[automationMenuTutorialStep+1].SetActive(true);
        automationMenuTutorialStep++;
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
        mainMenuTutorial.SetActive(false);
        mainMenuTutorialTitle.SetActive(false);
        foreach (GameObject obj in mainMenuExample)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in mainMenuOverlay)
        {
            obj.SetActive(false);
        }
        mainMenuTutorialShown = false;
        mainMenuTutorialStep = 0;
        automationMenuTutorial.SetActive(false);
        automationMenuTutorialTitle.SetActive(false);
        foreach (GameObject obj in automationMenuExample)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in automationMenuOverlay)
        {
            obj.SetActive(false);
        }
        automationMenuTutorialShown = false;
        automationMenuTutorialStep = 0;
    }
}
