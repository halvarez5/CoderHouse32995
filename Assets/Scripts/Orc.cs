using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator mAnimator;

    public int health = 150;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health > 0)
        {
            Vector3 target = (playerTransform.position - transform.position);

            if (target.magnitude < 10)
            {
                if (target.magnitude < 1)
                {
                    mAnimator.SetBool("trAttack", true);
                }
                else
                {
                    mAnimator.SetBool("trAttack", false);
                    mAnimator.SetBool("trWalk", true);
                    transform.position += target.normalized * Time.deltaTime * speed;
                    LookAtPlayer(target.normalized);
                }
            }
            else
            {
                mAnimator.SetBool("trWalk", false);
            }
        }
        else
        {
            mAnimator.SetTrigger("trDie");
            Destroy(gameObject, 3f);
        }
    }

    private void LookAtPlayer(Vector3 _target)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_target), 2 * Time.deltaTime);
    }
}
