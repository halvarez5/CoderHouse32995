using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : DestructibleEnemy
{
    enum DirectionMove
    {
        left,
        right
    }

    [SerializeField] private DirectionMove direction;
    [SerializeField] private Vector3 maxLocation;
    [SerializeField] private Vector3 minLocation;


    void Update()
    {
        if (health > 0)
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
        else
        {
            AnimationTrigger("trDie");
            Destroy(gameObject, 3f);
        }
    }
}
