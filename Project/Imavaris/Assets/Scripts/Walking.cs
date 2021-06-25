using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Walking : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    public SpriteRenderer character;
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
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", 1);
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", -1);
            anim.SetFloat("Walk", Math.Abs(move));
            
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", 1);
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", -1);
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(walkSpeed * Time.deltaTime, 0);
            float move = Input.GetAxis("Horizontal");
            anim.SetInteger("Direction", 2);
            character.flipX = false;
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-walkSpeed * Time.deltaTime, 0);
            float move = Input.GetAxis("Horizontal");
            character.flipX=true;
            anim.SetInteger("Direction", 2);
            
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if(Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector2(0, walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", 1);
            anim.SetFloat("Walk", Math.Abs(move));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = new Vector2(0, -walkSpeed * Time.deltaTime);
            float move = Input.GetAxis("Vertical");
            anim.SetInteger("Direction", -1);
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