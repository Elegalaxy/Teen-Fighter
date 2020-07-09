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
    public float Def = 1;
    float healC, timeC, durationC;
    float poisonTime;
    float poiDmg = 0;

    private void Start()
    {
        Def = 1;
        Health = maxHealth;
        poisonTime = 0;
        poiDmg = 0;
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

        if (poisonTime > 0)
        {
            poisonTime -= Time.deltaTime;
            Debug.Log(poisonTime);
            Health -= poiDmg * Def * Time.deltaTime;
            healthBar.GetComponent<HealthBar>().SetHealthBar();
        }
        else
        {
            gameObject.GetComponent<PlayerController>().runAmplifier = 1;
        }

        if (poison.isChaos)
        {
            if ((charsIndex.charsSelectedIndex != 6 && gameObject.GetComponent<PlayerController>().playerIndex == 1) || (charsIndex.charsSelectedIndex2 != 6 && gameObject.GetComponent<PlayerController>().playerIndex == 2))
            {
                Def *= 2f;
            }
        }
    }
    public void takeDamage(float damage)
    {
        Health -= damage * Def;

        if (poison.isPoisoned == true)
        {
            if((gameObject.GetComponent<PlayerController>().playerIndex == 1 && charsIndex.charsSelectedIndex != 3)
                || gameObject.GetComponent<PlayerController>().playerIndex == 2 && charsIndex.charsSelectedIndex2 != 3)
            {
                poisonApply(0.8f, 5f, 3f);
            }
        }

        if(poison.isChaos == true)
        {
            if(charsIndex.charsSelectedIndex != 6)
            {
                Def = Def * 1.3f;
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

    public void Regen(int heal, float time, float duration)
    {
        durationC = duration;
        healC = heal;
        timeC = time;
    }

    public void Regen(float duration)
    {
        durationC = duration;
    }

    public void poisonApply(float slow, float dmg, float time)
    {
        poisonTime = time;
        gameObject.GetComponent<PlayerController>().runAmplifier *= slow;
        poiDmg = dmg;
    }
}
