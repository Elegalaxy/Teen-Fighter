using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour
{
    public GameObject weaponSpawn;
    public Transform hitPoint;
    public GameObject bulletPrePis;
    public GameObject bulletPreShot;
    public GameObject bulletPreSnip;
    public GameObject bulletPreMac;
    public GameObject bulletPreLaz;
    public GameObject bulletPreGer;
    public GameObject loadPrefab;
    public int weaponPoint;

    public GameObject pistol;
    public GameObject shotgun;
    public GameObject sniper;
    public GameObject machineGun;
    public GameObject lazerGun;
    public GameObject gernade;

    public GameObject[] Sounds;
    public int soundIndex;

    /*
    public int weaponChange = 5; //admin script
    public int weaponChange2 = 4; //admin script
    */

    public int weaponCh;
    public int ammo;
    public int playerInd;
    GameObject bulletPrefab;
    GameObject bulletPrefab2;
    public GameObject text;

    public float coolDown = 1f;
    public float weaponCoolDown = 1f;

    public bool isTrigger = false;
    public bool takeWea = false;

    private void Start()
    {
        if (gameObject.GetComponent<PlayerController>().playerIndex == 1)
        {
            bulletAtrb(1, 1);
            weaponCh = 1;
            text.GetComponent<InGame>().changeBullet(playerInd);
        }
        else if (gameObject.GetComponent<PlayerController>().playerIndex == 2)
        {
            bulletAtrb(1, 2);
            weaponCh = 1;
            text.GetComponent<InGame>().changeBullet(playerInd);
        }
        playerInd = gameObject.GetComponent<PlayerController>().playerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponCoolDown > 0) //use to cooldown weapon
        {
            weaponCoolDown -= coolDown * Time.deltaTime;
        }

        if(ammo <= 0)
        {
            bulletAtrb(1, playerInd);
            text.GetComponent<InGame>().changeBullet(playerInd);
        }
        /*
        if (Input.GetKey(KeyCode.Space)) //admin script
        {
            bulletAtrb(weaponChange, 1);
            weaponSpawn.GetComponent<WeaponSpawn>().changeSprite();
            text.GetComponent<InGame>().changeBullet(1, weaponChange, ammo);
        }
        if (Input.GetKey(KeyCode.Backspace)) //admin script
        {
            bulletAtrb(weaponChange2, 2);
            weaponSpawn.GetComponent<WeaponSpawn>().changeSprite();
            text.GetComponent<InGame>().changeBullet(1, weaponChange2, ammo);
        }*/


        if (Input.GetButton("Fire1"))
        {
            if(gameObject.GetComponent<PlayerController>().playerIndex == 1)
            {
                Shoot();
            }
        }
        if (Input.GetButton("Fire2"))
        {
            if (gameObject.GetComponent<PlayerController>().playerIndex == 2)
            {
                Shoot();
            }
        }

        if (Input.GetButtonDown("Ability1"))
        {
            if (gameObject.GetComponent<PlayerController>().playerIndex == 1)
            {
                gameObject.GetComponent<Ability>().ability(charsIndex.charsSelectedIndex);
            }
        }

        if (Input.GetButtonDown("Ability2"))
        {
            if (gameObject.GetComponent<PlayerController>().playerIndex == 2)
            {
                gameObject.GetComponent<Ability>().ability(charsIndex.charsSelectedIndex2);
            }
        }

        if (Input.GetButtonDown("Interact1"))
        {
            if(gameObject.GetComponent<PlayerController>().playerIndex == 1)
            {
                if(isTrigger == true)
                {
                    Instantiate(loadPrefab);
                    bulletAtrb(weaponCh, 1);
                    weaponSpawn.GetComponent<WeaponSpawn>().changeSprite(weaponPoint);
                    text.GetComponent<InGame>().changeBullet(1, ammo);
                    takeWea = true;
                    isTrigger = false;
                }
            }
        }
        if (Input.GetButtonDown("Interact2"))
        {
            if (gameObject.GetComponent<PlayerController>().playerIndex == 2)
            {
                if (isTrigger == true)
                {
                    Instantiate(loadPrefab);
                    bulletAtrb(weaponCh, 2);
                    weaponSpawn.GetComponent<WeaponSpawn>().changeSprite(weaponPoint);
                    text.GetComponent<InGame>().changeBullet(2, ammo);
                    takeWea = true;
                    isTrigger = false;
                }
            }
        }
    }

    public void takeWeaponIndex(int weaponInd)
    {
        weaponCh = weaponInd+1;
    }

    void Shoot()
    {
        if(gameObject.GetComponent<PlayerController>().playerIndex == 1)
        {
            if (weaponCoolDown <= 0f)
            {
                Instantiate(bulletPrefab, hitPoint.position, hitPoint.rotation); //shooting logics
                if (weaponCh != 6)
                {
                    Instantiate(Sounds[soundIndex], hitPoint.position, hitPoint.rotation);
                }
                ammo -= 1;
                weaponCoolDown = 1f;
                text.GetComponent<InGame>().changeBullet(1, ammo);
            }
        }

        if (gameObject.GetComponent<PlayerController>().playerIndex == 2)
        {

            if (weaponCoolDown <= 0f)
            {
                Instantiate(bulletPrefab2, hitPoint.position, hitPoint.rotation); //shooting logics
                if (weaponCh != 6)
                {
                    Instantiate(Sounds[soundIndex], hitPoint.position, hitPoint.rotation);
                }
                ammo -= 1;
                weaponCoolDown = 1f;
                text.GetComponent<InGame>().changeBullet(2, ammo);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D point)
    {
        takeWeapon box = point.GetComponent<takeWeapon>();
        if (box != null && takeWea == true)
        {
            box.isTaken = true;
        }
    }

    void bulletAtrb(int weaponInd, int playerInd) //1Pistol, 2Shotgun, 3Sniper, 4Machine Gun, 5Lazer Gun, 6Gernade
    {
        if (playerInd == 1)
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            sniper.SetActive(false);
            machineGun.SetActive(false);
            lazerGun.SetActive(false);
            gernade.SetActive(false);
            if (weaponInd == 1)
            {
                pistol.SetActive(true);
                bulletPrefab = bulletPrePis;
                coolDown = 1f;
                soundIndex = 0;
            }
            else if (weaponInd == 2)
            {
                shotgun.SetActive(true);
                bulletPrefab = bulletPreShot;
                coolDown = 0.5f;
                ammo = 5;
                soundIndex = 1;
            }
            else if (weaponInd == 3)
            {
                sniper.SetActive(true);
                bulletPrefab = bulletPreSnip;
                coolDown = 0.5f;
                ammo = 3;
                soundIndex = 2;
            }
            else if (weaponInd == 4)
            {
                machineGun.SetActive(true);
                bulletPrefab = bulletPreMac;
                coolDown = 3f;
                ammo = 12;
                soundIndex = 3;
            }
            else if (weaponInd == 5)
            {
                lazerGun.SetActive(true);
                bulletPrefab = bulletPreLaz;
                coolDown = 0.3f;
                ammo = 7;
                soundIndex = 4;
            }
            else if (weaponInd == 6)
            {
                gernade.SetActive(true);
                bulletPrefab = bulletPreGer;
                coolDown = 0.5f;
                ammo = 1;
            }

        }
        else if (playerInd == 2)
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            sniper.SetActive(false);
            machineGun.SetActive(false);
            lazerGun.SetActive(false);
            gernade.SetActive(false);

            if (weaponInd == 1)
            {
                pistol.SetActive(true);
                bulletPrefab2 = bulletPrePis;
                coolDown = 1f;
                soundIndex = 0;
            }
            else if (weaponInd == 2)
            {
                shotgun.SetActive(true);
                bulletPrefab2 = bulletPreShot;
                coolDown = 0.5f;
                ammo = 5;
                soundIndex = 1;
            }
            else if (weaponInd == 3)
            {
                sniper.SetActive(true);
                bulletPrefab2 = bulletPreSnip;
                coolDown = 0.5f;
                ammo = 3;
                soundIndex = 2;
            }
            else if (weaponInd == 4)
            {
                machineGun.SetActive(true);
                bulletPrefab2 = bulletPreMac;
                coolDown = 3f;
                ammo = 12;
                soundIndex = 3;
            }
            else if (weaponInd == 5)
            {
                lazerGun.SetActive(true);
                bulletPrefab2 = bulletPreLaz;
                coolDown = 0.3f;
                ammo = 7;
                soundIndex = 4;
            }
            else if (weaponInd == 6)
            {
                gernade.SetActive(true);
                bulletPrefab2 = bulletPreGer;
                coolDown = 0.5f;
                ammo = 1;
            }
        }
    }

}
