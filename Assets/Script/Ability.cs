﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public bool unableMove = false;
    public int index;
    public float cd = 0, duration = 0, chargeDuration = 0, damage = 0;
    bool abilityStart = false, charging = false;
    public GameObject[] books;
    public GameObject booksPrefab;
    public int pointInd;
    public GameObject bookSound;
    public bookPrefab booksDamage;
    public CdBar cdBar;

    private void Start()
    {
        poison.isPoisoned = false;
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
            }
            else if (duration <= 0)
            {
                unableMove = false;
                gameObject.GetComponent<PlayerHealth>().Def = 1;
                gameObject.GetComponent<PlayerHealth>().Regen(0f);
                abilityStart = false;
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
                if(chargeDuration <= 0.5)
                {
                    damage = 20;
                }
                else if(chargeDuration > 0.5 && chargeDuration <= 1)
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

        }
        else if (index == 3)
        {
            if(duration <= 0)
            {
                poison.isPoisoned = false;
            }
        }
        else if (index == 4)
        {
            if(duration <= 0)
            {
                changeStat(1, 1, 1);
            }
        }
        else if (index == 5)
        {
            if (duration <= 0)
            {
                changeStat(1, 1, 1);
            }
        }
        else if (index == 6)
        {
            if (duration <= 0)
            {
                poison.isChaos = false;
            }
        }
        else if (index == 7)
        {

        }
        else if (index == 8)
        {

        }
        else if (index == 9)
        {

        }
        else if (index == 10)
        {

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
            PlayerHealth health = gameObject.GetComponent<PlayerHealth>();
            if (abilityStart == true)
            {
                duration = 0;
            }
            if (cd <= 0 && health.Health != health.maxHealth)
            {
                changeTime(20f, 9f);
                index = charInd;
                gameObject.GetComponent<PlayerHealth>().Def *= 0.2f;
                gameObject.GetComponent<PlayerHealth>().Regen(15, 1.5f, duration);
                abilityStart = true;
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
        else if (charInd == 2)
        {

        }
        else if (charInd == 3)
        {
            poison.isPoisoned = true;
            changeTime(15f, 5f);
        }
        else if (charInd == 4)
        {
            changeTime(15f, 5f);
            changeStat(1.3f, 0.7f, 0.6f);
        }
        else if (charInd == 5)
        {
            changeTime(15f, 5f);
            changeStat(1.4f, 1.6f, 1.4f);
        }
        else if (charInd == 6)
        {
            changeTime(15f, 6f);
            poison.isChaos = true;
        }
        else if (charInd == 7)
        {

        }
        else if (charInd == 8)
        {

        }
        else if (charInd == 9)
        {

        }
        else if (charInd == 10)
        {

        }
        else if (charInd == 11)
        {

        }

        if (cdBar.maxSlider == 100f)
        {
            cdBar.SetMax(cd);
        }
    }

    void bookExplode(float damage)
    {
        booksDamage.setBookDamage(damage);
        foreach(GameObject i in books)
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

    public void changeStat(float dmg, float speed, float atkAmplifier)
    {
        poison.dmgAmplify *= dmg;
        if(duration > 0)
        {
            gameObject.GetComponent<PlayerController>().changeSpeed(speed, true);
        }
        else
        {
            gameObject.GetComponent<PlayerController>().changeSpeed(speed, false);

        }
        gameObject.GetComponent<PlayerHealth>().Def *= atkAmplifier;
    }
}