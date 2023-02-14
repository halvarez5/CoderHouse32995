using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFalling : MonoBehaviour
{
    [SerializeField] private float secondsToFall = 1f;
    [SerializeField] private float speed = 3f;

    private bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        secondsToFall += Time.time;
    }

    // Update is called once per frame
    void Update()
    {        
        if (falling)
        {
            if (Time.time > secondsToFall)
            {
                Fall();
                falling = true;
                Destroy(gameObject, 3f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        falling = true;
        secondsToFall += Time.time;
    }

    private void Fall()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
