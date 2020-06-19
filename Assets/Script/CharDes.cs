using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharDes : MonoBehaviour
{
    public GameObject CharSelect;
    void Update()
    {
        int desIndex = CharSelect.GetComponent<CharSelect>().CharactersIndex; //get current index
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.SetText(CharSelect.GetComponent<CharSelect>().CharactersAbilityDes[desIndex]); //set descriptions
    }

}
