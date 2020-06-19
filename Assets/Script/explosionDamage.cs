using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDamage : MonoBehaviour
{
    public float bulletDamage = 100f;
    float delay = 0.3f;
    public GameObject explodeSound;

    private void Start()
    {
        Instantiate(explodeSound, transform.position, transform.rotation);
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth enemy = hitInfo.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(bulletDamage);
        }
    }
}
