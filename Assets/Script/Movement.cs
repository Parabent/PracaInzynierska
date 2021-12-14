using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float mS;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
    public Camera cam;
    public float angle;
    public Animator animator;
    private void Start()
    {
        mS = moveSpeed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(movement.x ==0 && movement.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        Vector2 lookDir = mousePos - rb.position;
        this.angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 88f;
        rb.rotation = angle;
    }
    public void SetMoveSpeed(bool speed)
    {
        if(speed)
        {
            moveSpeed = moveSpeed * 2;
            Debug.Log(moveSpeed);
        }
        else
        {
            moveSpeed = mS;
        }
        
    }
}