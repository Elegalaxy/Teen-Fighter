using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeWeapon : MonoBehaviour
{
    public int pointInd;
    public GameObject weaponIndex;
    int weaponCurrentIndex;
    public bool isTaken = false;
    private void Update()
    {
        if(weaponIndex.GetComponent<WeaponSpawn>().ran == pointInd)
        {
            weaponCurrentIndex = weaponIndex.GetComponent<WeaponSpawn>().wRan;
        }
    }
    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if(isTaken == false)
            {
                player.GetComponent<Weapon>().isTrigger = true;
                player.GetComponent<Weapon>().weaponPoint = pointInd;
                player.GetComponent<Weapon>().takeWeaponIndex(weaponCurrentIndex);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.GetComponent<Weapon>().isTrigger = false;
            player.GetComponent<Weapon>().weaponPoint = -1;
        }
    }

}
