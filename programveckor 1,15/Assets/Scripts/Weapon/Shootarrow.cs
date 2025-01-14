using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootarrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void Init(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
