using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapMenu : MonoBehaviour
{
    int[] levels = {1};
    int lvlIndex = 1;
    public MapIndex mapInd;

    public void Play()
    {
        mapInd.setMapInd(lvlIndex);
        //Debug.Log(lvlIndex);
        SceneManager.LoadScene(lvlIndex); //load next scene
    }

    public void setLevel(int x) //level choose
    {
        lvlIndex = x;
    }
}
