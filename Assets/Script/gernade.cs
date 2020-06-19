using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gernade : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explodeEffect;
    public float speed = 15f;
    public GameObject explosion;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player" || hitInfo.tag == "Ground")
        {
            Instantiate(explodeEffect, transform.position, transform.rotation);
            hitInfo.GetComponent<triggerShake>().triggerShak();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void destroyG()
    {
        Destroy(gameObject);
    }
}
