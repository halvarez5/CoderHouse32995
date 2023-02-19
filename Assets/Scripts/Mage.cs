using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public int health = 400;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator mAnimator;
    public GameObject Ball;

    private bool startAttack = false;

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
                if (!startAttack)
                {
                    startAttack = true;
                    Shoot();
                }
            }
            else
            {
                startAttack = false;
            }
        }
        else
        {
            startAttack = false;
            mAnimator.SetTrigger("trDie");
            Destroy(gameObject, 3f);
        }
    }

    private void Shoot()
    {
        if (startAttack)
        {
            mAnimator.SetTrigger("trAttack2");
            Invoke("CreateBall", 1f);
            Invoke("Shoot", 6f);
        }
    }

    private void CreateBall()
    {
        Instantiate(Ball);
    }
}
