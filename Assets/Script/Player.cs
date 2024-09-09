using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    public float CheckMove;
    public float Speed;
    public float MoveHigh;
    public float CheckJump = 0;
    public float EndGame = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move L,R,U
        if (Input.GetKey(KeyCode.RightArrow) && CheckMove == 1 && EndGame == 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && CheckMove == 1 && EndGame == 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CheckJump < 9999999)
            {
                rb.velocity = new Vector2(rb.velocity.x, MoveHigh);
                CheckJump++;
            }
        }

        //animation Hold , Run , Jump
        
        if(EndGame == 1)
        {
            transform.Translate(new Vector2(0.3f * Time.deltaTime, rb.velocity.y));
            transform.localScale = new Vector2(1, 1);
        }
    }

    //Target 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            CheckMove = 1;
        }
        if(collision.gameObject.CompareTag("Block Jump"))
        {
            CheckMove = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            CheckMove = 1;
        }
        if (collision.gameObject.CompareTag("Block Rotation"))
        {
            CheckMove = 0;
            rb.velocity = new Vector2(1, 1);
        }
        if(collision.gameObject.CompareTag("CoEnd"))
        {
            EndGame = 1;
        }
        if(collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
