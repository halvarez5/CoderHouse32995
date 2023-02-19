using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform initialPosition;

    void Start()
    {        
        rb.AddForce((Camera.main.transform.position - transform.position).normalized * 30, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }

}
