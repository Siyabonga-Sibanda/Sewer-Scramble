using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeLogic : MonoBehaviour
{
    public bool isBig;

    //Player components
    private Transform playerSize;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private PauseLogic pause;

    void Start()
    {
        isBig = false;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        playerSize = coll.GetComponent<Transform>();
        rb.mass = 1;
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.P))  && !isBig && !pause.isPaused) 
        {
            isBig = true;
            playerSize.localScale = new Vector3(1.5f, 1.5f);
            rb.mass = 3000;
        }
        else if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.P)) && isBig && !pause.isPaused)
        {
            isBig = false;
            playerSize.localScale = new Vector3(1f, 1f);
            rb.mass = 1;
        }
    }
}
