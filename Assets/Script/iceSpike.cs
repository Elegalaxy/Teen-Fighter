using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceSpike : MonoBehaviour
{
    float damage = 35;
    float speed = 20f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Ground") {
            destroy();
        }

        if(collision.GetComponent<PlayerHealth>() != null) {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            health.takeDamage(damage);
        }
    }

    public void destroy() {
        Destroy(gameObject);
    }
}
