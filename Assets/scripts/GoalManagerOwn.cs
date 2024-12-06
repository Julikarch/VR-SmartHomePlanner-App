using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GoalManagerOwn : MonoBehaviour
{


    [SerializeField]
    public GameObject card1;
    [SerializeField]
    public GameObject card2;
    [SerializeField]
    public GameObject card3;
    [SerializeField]
    public GameObject card4;
    [SerializeField]
    public GameObject card5Main;
    [SerializeField]
    public GameObject card6Main;
    [SerializeField]
    public GameObject card7Main;
    [SerializeField]
    public GameObject card8Main;
    [SerializeField]
    public GameObject card9Main;
    [SerializeField]
    public GameObject card10Main;
    [SerializeField]
    public GameObject welcomeUI;
    [SerializeField]
    public GameObject Menu;
    [SerializeField]
    public GameObject Automation;

    [SerializeField]
    Transform player;
    [SerializeField]
    float distance;
    [SerializeField]
    TMP_Text continueText;
    [SerializeField]
    TMP_Text skipText;

    [SerializeField]
    TutorialManager tutorialManager;

    [SerializeField]
    public bool nextClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextClicked){
            nextClicked = false;
            ContinueClicked();
        }
    }

    public void ContinueClicked()
    {
        if (card1.activeSelf)
        {
            card1.SetActive(false);
            card2.SetActive(true);
        }else if (card2.activeSelf)
        {
            card2.SetActive(false);
            card3.SetActive(true);
        } else if (card3.activeSelf)
        {
            card3.SetActive(false);
            card4.SetActive(true);
            // continueText.text = "Open Main Menu";
            // skipText.text = "Continue";
        } else if (card4.activeSelf)
        {
            // welcomeUI.SetActive(false);
            card4.SetActive(false);
            card5Main.SetActive(true);
            // Menu.transform.position = player.localPosition + Vector3.forward * distance;
            // tutorialManager.ShowMainTutorial();
        } else if(card5Main.activeSelf) {
            card5Main.SetActive(false);
            card6Main.SetActive(true);
        } else if(card6Main.activeSelf){
            card6Main.SetActive(false);
            card7Main.SetActive(true);
        } else if(card7Main.activeSelf){
            card7Main.SetActive(false);
            card8Main.SetActive(true);
        } else if(card8Main.activeSelf){
            card8Main.SetActive(false);
            card9Main.SetActive(true);
            // welcomeUI.SetActive(false);
            // Menu.transform.position = player.localPosition + Vector3.forward * distance;
            // Menu.SetActive(true);
        } else if(card9Main.activeSelf){
            card9Main.SetActive(false);
            card10Main.SetActive(true);
        } else if(card10Main.activeSelf){
            card10Main.SetActive(false);
            welcomeUI.SetActive(false);
            Automation.transform.position = player.localPosition + Vector3.forward * distance;
            Automation.SetActive(true);
        }
    }

    public void SkipClicked()
    {
        bool showMenu = false;
        if (card1.activeSelf)
        {
            card1.SetActive(false);
            showMenu = true;
        }else if (card2.activeSelf)
        {
            card2.SetActive(false);
            showMenu = true;
        } else if (card3.activeSelf)
        {
            card3.SetActive(false);
            showMenu = true;
        } else if (card4.activeSelf)
        {
            card4.SetActive(false);
            showMenu = true;
        } else if(card5Main.activeSelf) {
            card5Main.SetActive(false);
            showMenu = true;
        } else if(card6Main.activeSelf){
            card6Main.SetActive(false);
            showMenu = true;
        } else if(card7Main.activeSelf){
            card7Main.SetActive(false);
            showMenu = true;
        } else if(card8Main.activeSelf){
            card8Main.SetActive(false);
            showMenu = true;
        }
        welcomeUI.SetActive(false);
        Vector3 pos = player.position + Vector3.forward * distance;
        pos.y = 1f;
        if(showMenu){
            Menu.transform.position = pos;
            Menu.SetActive(true);
        } else {
            Automation.transform.position = pos;
            Automation.SetActive(true);
        
        }
    }
}
