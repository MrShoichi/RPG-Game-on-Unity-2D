using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Walking : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    [SerializeField] private float walkSpeed;

    private string Btn2Pressed;
    private string BtnPressed;
    private bool playerRuns;

    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string UP = "up";
    public const string DOWN = "down";

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //WALK
        if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.W))
        {
            BtnPressed = LEFT;
            Btn2Pressed = UP;
        }
        else if (Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.S))
        {
            BtnPressed = LEFT;
            Btn2Pressed = DOWN;
        }
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.W))
        {
            BtnPressed = RIGHT;
            Btn2Pressed = UP;
        }
        else if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.S))
        {
            BtnPressed = RIGHT;
            Btn2Pressed = DOWN;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            BtnPressed = RIGHT;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            BtnPressed = LEFT;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            BtnPressed = UP;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            BtnPressed = DOWN;
        }
        else
        {
            BtnPressed = null;
            Btn2Pressed = null;
        }

        //RUN
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRuns = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRuns = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRuns = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRuns = true;
            }
        }
        else
        {
            playerRuns = false;
        }
    }

    private void FixedUpdate()
    {
        if (playerRuns == true)
        {
            rb2d.velocity = new Vector2(walkSpeed * 2.0f * Time.deltaTime, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }

        //Walk
        if (BtnPressed == RIGHT & Btn2Pressed == UP)
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (BtnPressed == RIGHT && Btn2Pressed == DOWN)
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
            
        }
        else if (BtnPressed == LEFT & Btn2Pressed == UP)
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (BtnPressed == LEFT && Btn2Pressed == DOWN)
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (BtnPressed == RIGHT)
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, 0);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (BtnPressed == LEFT)
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, 0);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if(BtnPressed == UP)
        {
            rb2d.velocity = new Vector2(0, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (BtnPressed == DOWN)
        {
            rb2d.velocity = new Vector2(0, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            float move = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", 0);
        }
    }
}