using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject wSpawnPoint, wSpawnPoint2, wSpawnPoint3, wSpawnPoint4, wSpawnPoint5, wSpawnPoint6;
    GameObject[] pointList = new GameObject[6];
    public GameObject weapon, weapon2, weapon3, weapon4, weapon5, weapon6;
    Sprite[] wSpawnSprite = new Sprite[6];
    int y = 0;
    int x = 0;
    public int ran;
    public int wRan;
    float weaponSpawnTime = 15f;
    float spawnTime = 15f;

    void Start()
    {
        wGetSpawn(wSpawnPoint); //Apply all spawnpoint into a list
        wGetSpawn(wSpawnPoint2);
        wGetSpawn(wSpawnPoint3);
        wGetSpawn(wSpawnPoint4);
        wGetSpawn(wSpawnPoint5);
        wGetSpawn(wSpawnPoint6);
        wGetSprite(weapon);
        wGetSprite(weapon2);
        wGetSprite(weapon3);
        wGetSprite(weapon4);
        wGetSprite(weapon5);
        wGetSprite(weapon6);
        wGetRanNum(); //random point
    }

    private void Update()
    {
        weaponSpawnTime -= Time.deltaTime;
        if(weaponSpawnTime <= 0)
        {
            wGetRanNum(); //random point
            weaponSpawnTime = spawnTime;
        }
    }

    void wGetSpawn(GameObject point)
    {
        if (y <= 6)
        {
            pointList[y] = point;
            y++;
        }
    }


    void wGetSprite(GameObject weapon)
    {
        if(x <= 6)
        {
            Sprite spt = weapon.GetComponent<SpriteRenderer>().sprite;
            wSpawnSprite[x] = spt;
            x++;
        }
    }
    void wGetRanNum()
    {
        ran = Random.Range(0, 6); //random point
        wRan = Random.Range(1, 6); //random weapon
        pointList[ran].GetComponent<SpriteRenderer>().sprite = wSpawnSprite[wRan];
        pointList[ran].GetComponent<takeWeapon>().isTaken = false;
    }
    public void changeSprite(int x)
    {
        pointList[x].GetComponent<SpriteRenderer>().sprite = null;
    }

}
