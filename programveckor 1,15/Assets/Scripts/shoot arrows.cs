using System.Collections;
using System.Collections.Generic;
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

        if (timesfired <= 5)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(5, 0);
                timesfired = timesfired + 1;
            }
        }
          
    }
}
