using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPoint : MonoBehaviour
{
    public PlayerController player1, player2;
    public GameObject spawnPoint,spawnPoint2, spawnPoint3, spawnPoint4, spawnPoint5, spawnPoint6;
    Vector2[] spawnPointList = new Vector2[6];
    public Vector2 spawnPosition;
    public Vector2 spawnPosition2;
    int x = 0;

    void Start()
    {
        getSpawn(spawnPoint); //Apply all spawnpoint into a list
        getSpawn(spawnPoint2);
        getSpawn(spawnPoint3);
        getSpawn(spawnPoint4);
        getSpawn(spawnPoint5);
        getSpawn(spawnPoint6);
        getRanNum(); //random point
        player1.GetComponent<PlayerController>().startPosition();
        player2.GetComponent<PlayerController>().startPosition();
    }

    void getSpawn(GameObject point)
    {
        if (x <= 6)
        {
            Vector2 rand = point.GetComponent<Transform>().position; //transform spawnpoint position into list
            spawnPointList[x] = rand;
            x++;
        }
    }

    void getRanNum()
    {
        int ran = Random.Range(0, 6);
        int ran2 = Random.Range(0, 6);
        while(ran2 == ran) //random again if spawnpoint repeat
        {
            ran2 = Random.Range(0, 6);
        }
        spawnPosition = spawnPointList[ran];
        spawnPosition2 = spawnPointList[ran2];
    }
}
