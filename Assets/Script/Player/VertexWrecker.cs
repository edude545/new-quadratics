using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexWrecker : MonoBehaviour
{
    private Entity entity;
    private Rigidbody2D rb;
    public Animator animator;

    private static Quaternion right = new Quaternion(0, 0, 0, 0);
    private static Quaternion left = new Quaternion(0, -1, 0, 0);

    public float Speed;

    private void Awake()
    {
        entity = GetComponent<Entity>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float iHori = Input.GetAxis("Horizontal");
        float iJump = Input.GetAxis("Jump");
        rb.velocity = new Vector3(iHori*Speed, iJump, 0);
        if (iHori > 0)
        {
            transform.rotation = right;
        } else if (iHori < 0)
        {
            transform.rotation = left;
        }
        
        animator.SetBool("moving", iHori != 0);
    }
}
