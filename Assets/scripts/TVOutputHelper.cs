using System.Collections;
using System.Collections.Generic;
using scripst;
using scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TVOutputHelper : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        UpdateOutput();
    }

    public void UpdateOutput(){
        List<SpawnedObject> possibleObjects = ObjectSpawnerOwn.objekte.FindAll(e => e.gameObject.tag == "Speaker");
        if(dropdown.options.Count > 1){
            int i = dropdown.options.Count;
            while(i > 1){
                dropdown.options.RemoveAt(i-1);
                i--;
            }
            
        }
        foreach(SpawnedObject so in possibleObjects){
            dropdown.options.Add(new TMP_Dropdown.OptionData(so.name));
        }
    }
}
