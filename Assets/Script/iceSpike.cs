using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSpike : MonoBehaviour
{
    float damage = 35;
    float speed = 20f;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Ground") {
            //Destroy(gameObject);
        }

        if(collision.GetComponent<PlayerHealth>() != null) {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            health.takeDamage(damage);
        }
    }
}
