using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Enemy
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform initialPosition;

    void Start()
    {        
        rb.AddForce((Camera.main.transform.position - transform.position).normalized * speed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

}
