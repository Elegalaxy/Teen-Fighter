using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public CharSelect ind;
    public CharSelect ind2;
    public void QuitGame()
    {
        Debug.Log("Quit"); //quit
        Application.Quit();
    }

    public void resetMenu()
    {
        ind.CharactersIndex = 0;
        ind2.CharactersIndex = 1;
    }
}
