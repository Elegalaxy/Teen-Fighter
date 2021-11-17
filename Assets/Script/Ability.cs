﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public Animator animator;
    public bool unableMove = false;
    public int index;
    public float cd = 0, duration = 0, chargeDuration = 0, damage = 0;

    public int pointInd;
    public GameObject[] books;
    public GameObject booksPrefab;
    public GameObject bookSound;
    public bookPrefab booksDamage;
    public CdBar cdBar;
    public GameObject weapon;
    public GameObject stando;

    public GameObject iceSpike;
    public Transform icePoint;
    
    public bool isRole = false;

    bool charging = false;
    bool statChecker = false;

    private void Start()
    {
        poison.isPoisoned = false;
        poison.isChaos = false;
        poison.dmgAmplify = 1;

        cd = 0;
        duration = 0;

    }
    private void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }

        if (duration > 0)
        {
            duration -= Time.deltaTime;
            cdBar.SetDuration(duration);
        }
        else
        {
            cdBar.SetCD(cd);
        }

        if (index == 0)
        {
            if (duration > 0)
            {
                unableMove = true;
                gameObject.GetComponent<Weapon>().atkEnable = false;
                weapon.SetActive(false);
            }
            else if (duration <= 0)
            {
                animator.SetBool("Ability", false);
                unableMove = false;
                gameObject.GetComponent<Weapon>().atkEnable = true;
                weapon.SetActive(true);
                gameObject.GetComponent<PlayerHealth>().Def = 1;
                gameObject.GetComponent<PlayerHealth>().Regen(0f);
            }
        }
        else if (index == 1)
        {
            if (charging)
            {
                chargeDuration += Time.deltaTime;
                duration -= Time.deltaTime;
                unableMove = true;
            }
            if (chargeDuration > 0)
            {
                if (chargeDuration <= 0.5)
                {
                    damage = 20;
                }
                else if (chargeDuration > 0.5 && chargeDuration <= 1)
                {
                    damage = 40;
                }
                else if (chargeDuration > 1)
                {
                    damage = 60;
                }
            }
            if (chargeDuration >= 1.5)
            {
                bookExplode(damage);
                charging = false;
                unableMove = false;
                chargeDuration = 0;
            }
        }
        else if (index == 2)
        {
            if (duration <= 0 && statChecker)
            {
                isRole = false;
                animator.SetBool("Ability", false);
                gameObject.GetComponent<Weapon>().atkEnable = true;
                weapon.SetActive(true);
                changeStat(1f, 1.6f, 0.6f, true);
            }
        }
        else if (index == 3)
        {
            if (duration <= 0)
            {
                poison.isPoisoned = false;
            }
        }
        else if (index == 4)
        {
            if (duration <= 0 && statChecker)
            {
                changeStat(1.3f, 0.7f, 0.6f, true);
            }
        }
        else if (index == 5)
        {
            if (duration <= 0 && statChecker)
            {
                changeStat(1.4f, 1.6f, 1.4f, true);
            }
        }
        else if (index == 6)
        {
            if (duration <= 0)
            {
                poison.isChaos = false;
                poison.chaosPlayer[gameObject.getComponent<PlayerController>()] = false;
            }
        }
        else if (index == 7)
        {

        }
        else if (index == 8)
        {
            if (duration <= 0 && statChecker)
            {
                changeStat(1f, 1f, 0.01f, true);
            }
        }
        else if (index == 9)
        {
            if (duration <= 0)
            {
                poison.bleed = false;
            }
        }
        else if (index == 10)
        {
            if (duration <= 0 && statChecker)
            {
                changeStat(1.3f, 1.3f, 1f, true);
            }
        }
        else if (index == 11)
        {

        }
    }

    public void ability(int charInd)
    {
        index = charInd;
        if (charInd == 0)
        {
            if (duration != 0)
            {
                duration = 0;
            }

            if (cd <= 0)
            {
                PlayerHealth health = gameObject.GetComponent<PlayerHealth>();
                if (health.Health != health.maxHealth)
                {
                    animator.SetBool("Ability", true);
                    changeTime(20f, 9f);
                    index = charInd;
                    gameObject.GetComponent<PlayerHealth>().Def *= 0.2f;
                    gameObject.GetComponent<PlayerHealth>().Regen(15, 1.5f, duration, false);
                }
            }
        }
        else if (charInd == 1 && cd <= 0)
        {
            Instantiate(bookSound);
            if (charging)
            {
                bookExplode(damage);
                charging = false;
                unableMove = false;
                chargeDuration = 0;
            }
            changeTime(15f, 1.5f);
            charging = true;
        }
        else if (charInd == 2 && cd <= 0)
        {
            if (isRole)
            {
                isRole = false;
                animator.SetBool("Ability", false);
                changeStat(1f, 1.6f, 0.6f, true);
                gameObject.GetComponent<Weapon>().atkEnable = true;
                weapon.SetActive(true);
                duration = 0;
            }
            else
            {
                isRole = true;
                animator.SetBool("Ability", true);
                gameObject.GetComponent<Weapon>().atkEnable = false;
                weapon.SetActive(false);
                changeTime(15f, 7f);
                changeStat(1f, 1.6f, 0.6f, false);
            }
        }
        else if (charInd == 3 && cd <= 0)
        {
            poison.isPoisoned = true;
            changeTime(15f, 5f);
        }
        else if (charInd == 4 && cd <= 0)
        {
            changeTime(15f, 5f);
            unableMove = true;
            StartCoroutine("iceAbility");
            unableMove = false;
        }
        else if (charInd == 5 && cd <= 0)
        {
            changeTime(15f, 5f);
            changeStat(1.4f, 1.6f, 1.4f, false);
        }
        else if (charInd == 6 && cd <= 0)
        {
            changeTime(15f, 6f);
            poison.isChaos = true;
            poison.chaosPlayer = ;
        }
        else if (charInd == 7 && cd <= 0)
        {
            GameObject sd = Instantiate(stando);
            sd.GetComponent<stando>().setIndex(GetComponent<PlayerController>().playerIndex);
            changeTime(15f, 7f);
        }
        else if (charInd == 8 && cd <= 0)
        {
            changeTime(15f, 3f);
            changeStat(1f, 1f, 0.01f, false);
        }
        else if (charInd == 9 && cd <= 0)
        {
            poison.bleed = true;
            changeTime(15f, 8f);
        }
        else if (charInd == 10 && cd <= 0)
        {
            changeTime(15f, 5f);
            changeStat(1.3f, 1.3f, 1f, false);
            gameObject.GetComponent<PlayerHealth>().Regen(30, 0f, 0f, true);
        }
        else if (charInd == 11 && cd <= 0)
        {
            changeTime(15f, 0f);
        }

        if (cdBar.maxSlider == 100f)
        {
            cdBar.SetMax(cd);
        }
    }

    void bookExplode(float damage)
    {
        booksDamage.setBookDamage(damage);
        foreach (GameObject i in books)
        {
            Instantiate(booksPrefab, i.GetComponent<Transform>().position, i.GetComponent<Transform>().rotation);
        }
        bookPrefab.bookInd = 0;
    }

    void changeTime(float chCd, float chDuration)
    {
        cd = chCd;
        duration = chDuration;
    }

    public void changeStat(float dmg, float speed, float atkAmplifier, bool reset)
    {

        if (reset)
        {
            poison.dmgAmplify /= dmg;
            gameObject.GetComponent<PlayerController>().changeSpeed(speed, !reset);
            Debug.Log("reset");

            gameObject.GetComponent<PlayerHealth>().Def /= atkAmplifier;
            statChecker = false;
        }
        else
        {
            poison.dmgAmplify *= dmg;
            gameObject.GetComponent<PlayerController>().changeSpeed(speed, !reset);
            Debug.Log("no reset");

            gameObject.GetComponent<PlayerHealth>().Def *= atkAmplifier;
            statChecker = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (isRole == true && index == 2)
        {
            PlayerHealth enemy = hitInfo.GetComponent<PlayerHealth>();
            Rigidbody2D rb = hitInfo.GetComponent<Rigidbody2D>();
            if (enemy != null && rb != null)
            {
                enemy.takeDamage(5);
                rb.velocity = (-transform.right + transform.up) * 10;
            }
        }
    }

    IEnumerator iceAbility() {
        //Ice attack
        for(int i = 0; i < 3; i++) {
            Instantiate(iceSpike, icePoint.position, icePoint.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
