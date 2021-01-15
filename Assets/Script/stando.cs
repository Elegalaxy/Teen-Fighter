using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class stando : MonoBehaviour
{
    Animator animator;
    GameObject[] players;
    Transform currentPlayer;

    int index;
    bool isAttack = false;
    int atkTime;
    float charge;
    float atkDelay;
    float damage;
    float atkRange;

    private void Start()
    {
        atkTime = 3;
        charge = 1.5f;
        atkDelay = 0.5f;
        damage = 10f;
        atkRange = 5f;
        animator = GetComponent<Animator>();
        isAttack = false;
        players = GameObject.FindGameObjectsWithTag("Player"); //Find all player in the map
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector2(transform.position.x + atkRange, transform.position.y));
        if(atkTime > 0) {
            if(players != null && currentPlayer == null) {
                do { //guessing stuck on while
                    currentPlayer = players[Random.Range(0, players.Length - 1)].transform; //Random player
                } while(currentPlayer.gameObject.GetComponent<PlayerController>().playerIndex == index); //When target player is Kamboon, random again
            }
            
            if(!isAttack) {
                StartCoroutine("attack");
            }
        } else {
            Destroy(gameObject);
        }
    }

    IEnumerator attack() {
        isAttack = true;
        yield return new WaitForSeconds(charge); //Charge for 1.5 sec
        StartCoroutine("startAttack");
    }

    IEnumerator startAttack() {
        //Teleport and damage code
        transform.position = currentPlayer.transform.position;
        yield return new WaitForSeconds(atkDelay); //Tp and wait for 0.5 sec
        Debug.Log("Attack" + atkTime); //Atk after 0.5 sec
        dmg();
        atkTime--;
        isAttack = false;
    }

    void dmg() {
        Collider2D result;
        result = Physics2D.OverlapCircle(transform.position, atkRange, LayerMask.GetMask("Player"));
        if(result != null && result.transform == currentPlayer) {
            animator.SetTrigger("Attack");
            result.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }

    public void setIndex(int d) {
        index = d;
    }
}
