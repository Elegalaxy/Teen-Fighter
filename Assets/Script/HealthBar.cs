using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject player;

    private void Start()
    {
        float health = player.GetComponent<PlayerHealth>().maxHealth;
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealthBar()
    {
        float health = player.GetComponent<PlayerHealth>().Health;
        slider.value = health;
    }
}
