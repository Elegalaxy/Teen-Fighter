using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float Health;
    public GameObject deathEffect;
    public Animator animator;
    public GameObject healthBar;
    public float Def;
    float healC, timeC, durationC;
    float poisonTime;
    float poiDmg;
    float defHandler;

    private void Start()
    {
        Def = 1;
        Health = maxHealth;
        poisonTime = 0;
        poiDmg = 0;
        defHandler = 1;
    }

    private void Update()
    {
        if (durationC > 0)
        {
            if (Health >= maxHealth)
            {
                durationC = 0;
                gameObject.GetComponent<Ability>().duration = 0;
            }
            else
            {
                Health += healC * Time.deltaTime / timeC;
                healthBar.GetComponent<HealthBar>().SetHealthBar();
            }
        }
        //Debug.Log(poisonTime);
        if (poisonTime > 0)
        {
            poisonTime -= Time.deltaTime;
            Health -= poiDmg * Def * Time.deltaTime;
            healthBar.GetComponent<HealthBar>().SetHealthBar();
        }
        else
        {
            if (gameObject.GetComponent<PlayerController>() != null)
            {
                gameObject.GetComponent<PlayerController>().runAmplifier = 1;

            }
        }

        if (poison.isChaos)
        {
            if ((charsIndex.charsSelectedIndex != 6 && gameObject.GetComponent<PlayerController>().playerIndex == 1) || (charsIndex.charsSelectedIndex2 != 6 && gameObject.GetComponent<PlayerController>().playerIndex == 2))
            {
                defHandler = 1.3f;
            }
        }
    }

    public void takeDamage(float damage)
    {
        Def *= defHandler;
        Health -= damage * Def;

        if (poison.isPoisoned)
        {
            if ((gameObject.GetComponent<PlayerController>().playerIndex == 1 && charsIndex.charsSelectedIndex != 3)
                || gameObject.GetComponent<PlayerController>().playerIndex == 2 && charsIndex.charsSelectedIndex2 != 3)
            {
                poisonApply(0.8f, 5f, 3f);
            }
        }

        if(poison.isChaos)
        {
            if(charsIndex.charsSelectedIndex != 6)
            {
                Def = Def * 1.3f;
            }
        }

        if (poison.bleed)
        {
            if ((gameObject.GetComponent<PlayerController>().playerIndex == 1 && charsIndex.charsSelectedIndex != 9)
                || gameObject.GetComponent<PlayerController>().playerIndex == 2 && charsIndex.charsSelectedIndex2 != 9)
            {
                poisonApply(1.15f, 10f, 4f);
            }
        }

        if (Health <= 0)
        {
            die();
        }
        animator.SetTrigger("Hitted");
        healthBar.GetComponent<HealthBar>().SetHealthBar();
    }

    void die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void Regen(int heal, float time, float duration, bool instant)
    {
        if (!instant)
        {
            durationC = duration;
            healC = heal;
            timeC = time;
        }else if (instant)
        {
            if((Health + heal) <= maxHealth)
            {
                Health += heal;
            }
            else
            {
                Health += (maxHealth - Health);
            }
            healthBar.GetComponent<HealthBar>().SetHealthBar();
        }
    }

    public void Regen(float duration)
    {
        durationC = duration;
    }

    public void poisonApply(float slow, float dmg, float time)
    {
        gameObject.GetComponent<PlayerController>().runAmplifier *= slow;
        poiDmg = dmg;
        poisonTime = time;
    }
}
