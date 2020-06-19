using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGame : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;

    void Start()
    {
        text.GetComponent<TextMeshProUGUI>().SetText("Bullet: Unlimited");
        text2.GetComponent<TextMeshProUGUI>().SetText("Bullet: Unlimited");
    }

    public void changeBullet(int charInd, int ammo)
    {
        if(charInd == 1)
        {
            text.GetComponent<TextMeshProUGUI>().SetText("Bullet: " + ammo);
        }
        else if(charInd == 2)
        {
            text2.GetComponent<TextMeshProUGUI>().SetText("Bullet: " + ammo);
        }
    }

    public void changeBullet(int charInd)
    {
        if (charInd == 1)
        {
            text.GetComponent<TextMeshProUGUI>().SetText("Bullet: Unlimited");
        }
        else if (charInd == 2)
        {
            text2.GetComponent<TextMeshProUGUI>().SetText("Bullet: Unlimited");
        }
    }
}
