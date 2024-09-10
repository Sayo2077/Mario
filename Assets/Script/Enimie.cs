using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Enimie : MonoBehaviour
{
    public GameObject enime;
    private float playerY;
    private float enimeY;
    public float target = 0;
    public string NameLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         enimeY = enime.transform.position.y;
        playerY = transform.position.y;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nam"))
        {
            if (playerY > enimeY)
            {
                Destroy(collision.gameObject);
                target++;
            }
            if (playerY <= enimeY)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(NameLevel);
            }
        }
    }
}
