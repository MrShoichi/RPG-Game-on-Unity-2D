using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalking : MonoBehaviour
{
    public float movementSpeed = 1f;   
    public Vector2 movement;          
    public Rigidbody2D rigidbody;
    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;
    private Transform cameraPos;
    private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        bool b;
        movement = movement.normalized;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // “от самый поворот
        // вычисл€ем разницу между текущим положением и положением мыши
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        // вычисл€емый необходимый угол поворота
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // ѕримен€ем поворот вокруг оси Z
        hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
        vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        b = movement.x < 0 ? true : false;
        anim.SetFloat("Horizontal", hf);
        anim.SetBool("Back", b);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", vf);
        if (rotation_z > 40 && rotation_z < 140)
        {
            anim.SetFloat("Direction", -1);
        }
        else if(rotation_z > -140 && rotation_z < -40)
        {
            anim.SetFloat("Direction", 0);
        }
        else if(rotation_z < -140 || rotation_z > 140)
        {
            anim.SetFloat("Direction", 2);
        }
        else
        {
            anim.SetFloat("Direction", 1);
        }
        
    }
    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
