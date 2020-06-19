using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falloutZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.takeDamage(1000);
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        gernade Gernade = collision.GetComponent<gernade>();
        books Books = collision.GetComponent<books>();
        if(bullet != null)
        {
            bullet.destory();
        }
        else if (Gernade != null)
        {
            Gernade.destroyG();
        }
        else if(Books != null)
        {
            Books.destory();
        }
    }
}
