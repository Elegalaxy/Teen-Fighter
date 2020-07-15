using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class books : MonoBehaviour
{
    float bookSpeed = 15f;
    float bookDamage;
    public Rigidbody2D rb;
    public bookPrefab pref;

    private void Start()
    {
        bookDamage = bookPrefab.damage;
        if (bookPrefab.bookInd == 0)
        {
            rb.velocity = (-transform.right + transform.up) * bookSpeed;
        }
        else if (bookPrefab.bookInd == 1)
        {
            rb.velocity = transform.up * bookSpeed;
        }
        else if (bookPrefab.bookInd == 2)
        {
            rb.velocity = (transform.right + transform.up) * bookSpeed;
        }
        else if (bookPrefab.bookInd == 3)
        {
            rb.velocity = transform.right * bookSpeed;
        }
        else if (bookPrefab.bookInd == 4)
        {
            rb.velocity = (transform.right - transform.up) * bookSpeed;
        }
        else if (bookPrefab.bookInd == 5)
        {
            rb.velocity = -transform.up * bookSpeed;
        }
        else if (bookPrefab.bookInd == 6)
        {
            rb.velocity =  (-transform.right - transform.up) * bookSpeed;
        }
        else if (bookPrefab.bookInd == 7)
        {
            rb.velocity = - transform.right * bookSpeed;
        }
        pref.GetComponent<bookPrefab>().setBookInd();
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth enemy = hitInfo.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(bookDamage);
            Destroy(gameObject);
        }

        if (hitInfo.tag == "Ground")
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

