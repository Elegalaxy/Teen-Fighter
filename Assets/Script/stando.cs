using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class stando : MonoBehaviour
{
    GameObject[] players;
    GameObject currentPlayer;


    bool isAttack = false;
    int atkTime = 3;
    float charge = 1.5f;
    float atkDelay = 0.5f;
    float damage = 10f;

    private void Start()
    {
        isAttack = false;
        players = GameObject.FindGameObjectsWithTag("Player"); //find all player in the map
    }

    private void Update()
    {
        if(atkTime > 0) {
            if(players != null && currentPlayer == null)
                currentPlayer = players[Random.Range(0, players.Length - 1)];
            else if(!isAttack) {
                StartCoroutine("attack");
            }
        }
    }

    IEnumerator attack() {
        isAttack = true;
        StartCoroutine("startAttack");
        yield return new WaitForSeconds(charge);
    }

    IEnumerator startAttack() {
        //Teleport and damage code

        yield return new WaitForSeconds(atkDelay);
    }
}
