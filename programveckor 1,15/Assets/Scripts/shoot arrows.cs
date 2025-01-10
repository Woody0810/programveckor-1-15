using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shootarrows : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    int timesfired;
    // Start is called before the first frame update
    void Start()
    {
        timesfired = 0;
    }

    // Update is called once per frame
  
    private void Update()
    {

        if (timesfired <= 12)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(5, 0);
                timesfired = timesfired + 1;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("arrow") && (timesfired>=12) )
        { 
            collision.gameObject.SetActive(false);
            timesfired = timesfired - 3;
        }
        
    }
}
