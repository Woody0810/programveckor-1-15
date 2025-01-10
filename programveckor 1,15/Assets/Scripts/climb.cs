using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movespeed, dirX, dirY;
    public bool ClimbingAllowed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClimbingAllowed)
        {
            movespeed = 5f;
            dirY = Input.GetAxisRaw("Vertical") * movespeed;
        }
    }
    private void FixedUpdate()
    {
        if (ClimbingAllowed)
        {
            rb.velocity = new Vector2(rb.velocity.x, dirY);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, dirY);
        }
    }

}
