using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float oldX;
    public float oldY;
    public Enemy enemy;
    public float period = 0.0f;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float fMinX = 0f;
    private float fMaxX = -4f;
    public bool onAim;
    public bool onMovement;
    int Direction = -1;
    private Movement charMovement;
    public bool onMoveToPlayer;
    private Transform target;
    public float speed = 2f;
    public float minDistance = 10f;
    public float maxDistance = 30f;
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        fMinX = rb.position.x;
        charMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onMovement)
        {
            switch (Direction)
            {
                case -1:

                    if (rb.position.x >= fMinX)
                    {
                        movement.x = -1.0f;
                    }
                    else
                    {
                        Direction = 1;
                    }
                    break;

                case 1:

                    if (rb.position.x <= fMaxX)
                    {
                        movement.x = 1f;
                    }
                    else
                    {
                        Direction = -1;
                    }
                    break;
            }
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        if(onAim)
        {
            Vector2 lookDir = charMovement.GetComponent<Movement>().rb.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 92f;
            rb.rotation = angle;

        }
        if (onMoveToPlayer)
        {
            range = Vector2.Distance(transform.position, target.position);

            if (range > minDistance && range < maxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        period += UnityEngine.Time.deltaTime;
    }
    private void Awake()
    {
        charMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
