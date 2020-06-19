using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsClimb : MonoBehaviour
{
    public bool isClimb = false;
    public bool isClimb2 = false;

    void OnTriggerStay2D(Collider2D other) //detect ladder
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if(playerController != null)
        {
            int ind = playerController.playerIndex;
            if (ind == 1)
            {
                isClimb = true;
            }
            if (ind == 2)
            {
                isClimb2 = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            int ind = playerController.playerIndex;
            if (ind == 1)
            {
                isClimb = false;
            }
            if (ind == 2)
            {
                isClimb2 = false;
            }
        }
    }
}
