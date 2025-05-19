using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBehaviour : MonoBehaviour
{
    private HingeJoint2D joint;
    private Rigidbody2D rb;
    [SerializeField] private SizeLogic size;
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !size.isBig)
        {
            joint.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
        else if (collision.gameObject.CompareTag("Player") &&  size.isBig)
        {
            joint.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        joint.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
