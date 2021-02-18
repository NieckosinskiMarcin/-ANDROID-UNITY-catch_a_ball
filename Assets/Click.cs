using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public static Click instance;
    public Rigidbody2D theRB;
    public float moveSpeed = 0.1f;
    private Vector3 moveDirection = Vector3.zero;
    private float timeToDestroy = 6f;
    private float goodClickDestroy = 4f;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        goodClickDestroy -= Time.deltaTime;
        if (this.moveDirection == Vector3.zero)
        {
            moveDirection = Vector3.zero - transform.position;
        }
        theRB.velocity = moveDirection * moveSpeed;
        if(timeToDestroy <= 0)
        {
            if(this.tag == "goodClick" && goodClickDestroy <= 0)
            {
                TouchInput.score -= 10;
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
