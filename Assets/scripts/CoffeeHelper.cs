using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeHelper : MonoBehaviour
{
    [SerializeField] public GameObject coffee;

    public void BtnClicked(){
        coffee.SetActive(true);
    }

    public void RestClicked(){
        coffee.SetActive(false);
    }
}
