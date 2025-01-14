using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon.Interfaces;
using Weapon.Projectiles;

public class Followquerser : MonoBehaviour
{
    [SerializeField,Range(1, 100)] private float _rotationSpeed = 1;
    [SerializeField] private Arrow arrowprojektile;
    [SerializeField] private Transform spawnpoint;
    private Camera _cam;
    void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseposition = _cam.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;

        transform.up = Vector3.MoveTowards(transform.up, mouseposition, _rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
      {
            Instantiate(arrowprojektile, spawnpoint.position, Quaternion.identity).GetComponent<Shootarrow>().Init(transform.up);
      }
    }
}
