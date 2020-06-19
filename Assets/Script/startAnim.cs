using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnim : MonoBehaviour
{
    public Animator animator;
    public int playerIndex = 1;

    void Start()
    {
        if (MapIndex.isRestart == true)
        {
            if (playerIndex == 1)
            {
                setAnim(MapIndex.playerInd);

            }
            if (playerIndex == 2)
            {
                setAnim(MapIndex.playerInd2);

            }
            Debug.Log("initiate char setted");
        }
        else
        {
            setAnim(playerIndex);
        }
    }

    public void setAnim(int x)
    {
        if (x == 1)
        {
            animator.SetInteger("CharInt", charsIndex.charsSelectedIndex); //trigger animation depend on which char choosen
        }
        else if (x == 2)
        {
            animator.SetInteger("CharInt", charsIndex.charsSelectedIndex2); //trigger animation depend on which char choosen
        }
    }
}
