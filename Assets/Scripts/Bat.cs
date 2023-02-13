using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Vector3 maxLocation;
    private Vector3 minLocation;

    private void Awake()
    {
        maxLocation = transform.position + new Vector3(3, 3, 3);
        minLocation = transform.position + new Vector3(-3, -3, -3);

        Debug.Log(maxLocation);
        Debug.Log(minLocation);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (maxLocation.x > transform.position.x && minLocation.x < transform.position.x)
            transform.position += transform.forward * speed * Time.deltaTime;
        else
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (maxLocation.y > transform.position.y && minLocation.y < transform.position.y)
            transform.position += transform.forward * speed * Time.deltaTime;
        else
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (maxLocation.z > transform.position.z && minLocation.z < transform.position.z)
            transform.position += transform.forward * speed * Time.deltaTime;
        else
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
