using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTwoMoves : MonoBehaviour
{
    enum DirectionMove
    {
        left,
        right
    }

    [SerializeField] private float speed = 1f;
    [SerializeField] private DirectionMove direction;
    [SerializeField] private Vector3 maxLocation;
    [SerializeField] private Vector3 minLocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case DirectionMove.left:
                if (Vector3.Distance(transform.position, maxLocation) < 0.1f)
                {
                    direction = DirectionMove.right;
                }
                break;
            case DirectionMove.right:
                if (Vector3.Distance(transform.position, minLocation) < 0.1f)
                {
                    direction = DirectionMove.left;
                }
                break;
            default:
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, (direction == DirectionMove.left) ? maxLocation : minLocation, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
