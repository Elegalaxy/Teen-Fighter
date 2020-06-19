using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedLevel : MonoBehaviour
{
    public void selectLevel(RectTransform lvl)
    {
        float x = lvl.GetComponent<RectTransform>().position.x; //show which level selected
        float y = lvl.GetComponent<RectTransform>().position.y;
        transform.position = new Vector2(x,y);
    }
}
