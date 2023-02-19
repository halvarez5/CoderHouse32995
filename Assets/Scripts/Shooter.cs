using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Ball;

    void Start()
    {
        Invoke("Shoot", 5f);
    }

    private void Shoot()
    {
        Instantiate(Ball);
        Invoke("Shoot", 5f);
    }
}
