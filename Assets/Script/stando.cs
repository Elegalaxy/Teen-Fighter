using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class stando : MonoBehaviour
{
    Vector2[] targetLocation;

    public float runAmplifier = 1f;

    float runSpeed = 5.5f;
    float climbSpeed = 4f;
    float jumpForce = 2f;
    float distanceBetween = 1f;
    bool moveLeft = true;
    bool idle = true;
    bool isGround = true;

    private void Start()
    {
        GameObject[] player;
        player = GameObject.FindGameObjectsWithTag("Player"); //find all player in the scene

        int num;
        num = player.Length; //player number

        targetLocation = new Vector2[num];
        int locationInd = 0;
        for (int i = 0; i < num; i++) //get all player position which is not Kamboon
        {
            if (player[i].GetComponent<Ability>().index != 7)
            {
                targetLocation[locationInd] = player[i].transform.position;
                locationInd++;
            }
        }
    }

    private void Update()
    {
        if (!isGround)
        {
            idle = true;
        }

        if (!idle) //walk
        {
            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
        }

        if (gameObject.GetComponent<seeker>().findPosition(targetLocation) != null)
        {
            Vector2 target = gameObject.GetComponent<seeker>().findPosition(targetLocation); //find target
            Vector2 stando = transform.position;

            if (Mathf.Abs(target.y - stando.y) <= 0.99f) //if same height
            {
                if ((target.x - stando.x) > distanceBetween) //walk until reach the player
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    idle = false;
                    bool moveLeft = false;
                }
                else if ((target.x - stando.x) < -distanceBetween)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    idle = false;
                    bool moveLeft = true;
                }
                else
                {
                    idle = true;
                }
            }
            else if ((target.y - stando.y) < -0.99f) //if not the same height
            {
                if (gameObject.GetComponent<seeker>().findDistance(target) != null)
                {
                    Vector2 distance = gameObject.GetComponent<seeker>().findDistance(target);
                    if (distance.x < transform.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        idle = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        idle = false;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //ground check
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            isGround = false;
        }
    }
}
