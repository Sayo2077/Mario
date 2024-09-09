using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveEnimes : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enimeScaleX;
    public float Check;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enimeScaleX = transform.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(enimeScaleX,rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block Rotation"))
        {
            if(enimeScaleX == 1 || enimeScaleX == 0.7f )
            {
                enimeScaleX = -0.7f;
                transform.localScale = new Vector3(1, 1, 1);
            } else
            {
                if(enimeScaleX == -1 || enimeScaleX == -0.7f )
                {
                    enimeScaleX = 0.7f;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
}
