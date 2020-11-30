using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedChar : MonoBehaviour
{
    public GameObject Char_1, Char_2;
    public charsIndex ind;
    public int Char1, Char2;

    public void selectChar()
    {
        int Char1 = Char_1.GetComponent<CharSelect>().CharactersIndex; //get index
        int Char2 = Char_2.GetComponent<CharSelect>().CharactersIndex;
        ind.setInd(Char1,Char2); //set index
    }
}
