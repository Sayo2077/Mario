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
    private float NumberScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        NumberScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Move L,R,U
        if (Input.GetKey(KeyCode.RightArrow) && CheckMove == 1 && EndGame == 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
            transform.localScale = new Vector3(NumberScale, NumberScale, NumberScale);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && CheckMove == 1 && EndGame == 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
            transform.localScale = new Vector3(-NumberScale, NumberScale, NumberScale);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CheckJump < 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, MoveHigh);
                CheckJump++;
            }
        }

        //animation Hold , Run , Jump
        
        if(EndGame == 1)
        {
            transform.Translate(new Vector2(0.5f * Time.deltaTime, rb.velocity.y));
            transform.localScale = new Vector2(NumberScale, NumberScale);
        }
    }

    //Target 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            CheckMove = 1;
            CheckJump = 0;
        }
        if(collision.gameObject.CompareTag("Block Jump"))
        {
            CheckMove = 0;
        }
        if(collision.gameObject.CompareTag("PhongTo"))
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector2(1.5f,1.5f);
            NumberScale = 1.5f;
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
