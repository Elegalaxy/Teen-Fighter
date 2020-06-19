using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIndex : MonoBehaviour
{
    static public int mapInd;
    static public bool isRestart = false;
    static public int playerInd;
    static public int playerInd2;

    public void setMapInd(int x)
    {
        mapInd = x;
    }

    public void setCharInd(int y, int z)
    {
        isRestart = true;
        if(isRestart == true)
        {
            playerInd = y;
            playerInd2 = z;
            isRestart = false;
        }
    }
}
