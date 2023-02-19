using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public int health = 400;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health > 0)
        {
            Vector3 target = (playerTransform.position - transform.position);

            if (target.magnitude < 35)
            {
                Debug.Log("esta en mi territorio!");
            }
        }
        else
        {
            mAnimator.SetTrigger("trDie");
            Destroy(gameObject, 3f);
        }
    }
}
