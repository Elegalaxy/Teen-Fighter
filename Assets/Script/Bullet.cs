using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject ImpactObject;
    public float speed = 15f;
    public float bulletDamage = 10f;
    public float dmgAmplifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        dmgAmplifier = poison.dmgAmplify;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth enemy = hitInfo.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(bulletDamage*dmgAmplifier);
            Destroy(gameObject);
        }

        if(hitInfo.tag == "Ground")
        {
            Destroy(gameObject);
        }
        //Instantiate(ImpactObject, transform.position, transform.rotation);
    }

    public void destory() //call when bulet get out of deadzone
    {
        Destroy(gameObject);
    }
}
