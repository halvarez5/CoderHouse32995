using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orc : DestructibleEnemy
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip sfx_die;

    public UnityEvent OnEnemyDie;

    private void Start()
    {
        audioSrc.clip = sfx_die;
        OnEnemyDie.AddListener(Die);
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
                    AnimationBool("trAttack", true);
                }
                else
                {
                    AnimationBool("trAttack", false);
                    AnimationBool("trWalk", true);
                    transform.position += target.normalized * Time.deltaTime * entityData.speed;
                    LookAtPlayer(target.normalized);
                }
            }
            else
            {
                AnimationBool("trWalk", false);
            }
        }
        else
        {
            OnEnemyDie?.Invoke();
            OnEnemyDie.RemoveListener(Die);
        }
    }

    private void Die()
    {
        AnimationTrigger("trDie");
        audioSrc.Play();
        Destroy(gameObject, 3f);
    }

    private void LookAtPlayer(Vector3 _target)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_target), 2 * Time.deltaTime);
    }
}
