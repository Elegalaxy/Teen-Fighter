using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //vars
    float runSpeed = 5.5f;
    float runAmplifier = 1f;
    float climbSpeed = 4f;
    float jumpForce = 2f;

    public int playerIndex = 1;
    float horizontalMove;
    float horizontalMove2;
    //comfirmation
    public bool isGrounded = false;
    public bool isGrounded2 = false;
    bool isWalking = false;
    //pub obj
    public GameObject isClimbs;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject spawnPoint;
    public GameObject healthBar;

    private void Start()
    {
        healthBar.GetComponent<HealthBar>().SetHealthBar();
        if(!poison.chaosStarter.ContainsKey(playerIndex))
            poison.chaosStarter.Add(playerIndex, false);
    }

    private void Update()
    {
        Jump(); //detect jump and climb
    }

    void FixedUpdate()
    {
        if (playerIndex == 1 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            if (Input.GetAxisRaw("Horizontal") < 0) //flip facing
            {
                transform.rotation = Quaternion.Euler(new Vector2(0f, 0f));
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector2(0f, 180f));
            }
            if (Input.GetAxisRaw("Horizontal") != 0) //detect walking
            {
                isWalking = true;
            }
            else if (Input.GetAxisRaw("Horizontal") == 0)
            {
                isWalking = false;
            }
        }
        else if (playerIndex == 2 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            horizontalMove2 = Input.GetAxisRaw("Horizontal2");
            if (Input.GetAxisRaw("Horizontal2") < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector2(0f, 0f));
            }
            else if (Input.GetAxisRaw("Horizontal2") > 0)
            {
                transform.rotation = Quaternion.Euler(new Vector2(0f, 180f));
            }
            if (Input.GetAxisRaw("Horizontal2") != 0)
            {
                isWalking = true;
            }
            else if (Input.GetAxisRaw("Horizontal2") == 0)
            {
                isWalking = false;
            }
        }
        animator.SetBool("IsWalking", isWalking);

        if(poison.isChaos && !poison.chaosStarter[playerIndex]) {
            runAmplifier *= 0.8f;
        }

        if(playerIndex == 1 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            Vector3 movement = new Vector3(horizontalMove, 0f, 0f); //basic movement
            transform.position += movement * Time.fixedDeltaTime * runSpeed * runAmplifier;
        }
        if (playerIndex == 2 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            Vector3 movement = new Vector3(horizontalMove2, 0f, 0f);
            transform.position += movement * Time.fixedDeltaTime * runSpeed * runAmplifier;
        }

    }

    void Jump()
    {
        if (playerIndex == 1 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            if (Input.GetButtonDown("Jump")) //jump button
            {
                if (isGrounded == true && isClimbs.GetComponent<IsClimb>().isClimb == false)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f * jumpForce), ForceMode2D.Impulse);
                    isGrounded = false;

                }

            }
            if (isClimbs.GetComponent<IsClimb>().isClimb == true) //climb
            {
                rb.gravityScale = 0;
                if (isGrounded == false)
                {
                    rb.velocity = Vector2.zero;
                }
                if (Input.GetButton("Jump") || Input.GetButton("ClimbDown"))
                {
                    Vector3 movementV = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    transform.position += movementV * Time.deltaTime * climbSpeed;
                }
            }
            else if (isClimbs.GetComponent<IsClimb>().isClimb == false)
            {
                rb.gravityScale = 2;
            }

        }

        if (playerIndex == 2 && gameObject.GetComponent<Ability>().unableMove == false)
        {
            if (Input.GetButtonDown("Jump2")) //jump button
            {
                if (isGrounded2 == true && isClimbs.GetComponent<IsClimb>().isClimb2 == false)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f * jumpForce), ForceMode2D.Impulse);
                    isGrounded2 = false;

                }

            }
            if (isClimbs.GetComponent<IsClimb>().isClimb2 == true) //climb
            {
                rb.gravityScale = 0;
                if (isGrounded2 == false)
                {
                    rb.velocity = Vector2.zero;
                }
                if (Input.GetButton("Jump2") || Input.GetButton("ClimbDown2"))
                {
                    Vector3 movementV = new Vector3(0f, Input.GetAxisRaw("Vertical2"), 0f);
                    transform.position += movementV * Time.deltaTime * climbSpeed;
                }
            }
            if (isClimbs.GetComponent<IsClimb>().isClimb2 == false)
            {
                rb.gravityScale = 2;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) //ground check
    {
        if (playerIndex == 1)
        {
            if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
            {
                isGrounded = true;
            }
        }
        if (playerIndex == 2)
        {
            if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
            {
                isGrounded2 = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playerIndex == 1)
        {
            if (other.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }
        if (playerIndex == 2)
        {
            if (other.gameObject.tag == "Ground")
            {
                isGrounded2 = false;
            }
        }
    }

    public void startPosition()
    {
        if (playerIndex == 1)
        {
            transform.position = spawnPoint.GetComponent<RandomSpawnPoint>().spawnPosition;
        }

        if (playerIndex == 2)
        {
            transform.position = spawnPoint.GetComponent<RandomSpawnPoint>().spawnPosition2;
        }
    }

    public void changeSpeed(float speed, bool enable)
    {
        if(enable)
        {
            runAmplifier *= speed;
        }
        else
        {
            runAmplifier /= speed;
        }

    }

    public void resetSpeed() {
        runAmplifier = 1;
    }
}