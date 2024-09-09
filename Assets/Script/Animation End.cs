using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{
    private Animator ani;
    private float end = 0;
    private float check = 0;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(check <=1)
        {
            ani.SetBool("End", end == 1);
        }
        if(check > 1)
        {
            ani.SetBool("Rs", end == 1);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            end = 1;
            check++;
        }
    }
}
