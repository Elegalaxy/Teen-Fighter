using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookPrefab : MonoBehaviour
{
    public static int bookInd = 0;
    public static float damage;

    public void setBookInd()
    {
        bookInd += 1;
    }

    public void setBookDamage(float dmg)
    {
        damage = dmg;
    }

}
