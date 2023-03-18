using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bat : DestructibleEnemy
{
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip sfx_die;

    private Vector3 maxLocation;
    private Vector3 minLocation;

    public UnityEvent OnEnemyDie;

    private void Awake()
    {
        maxLocation = transform.position + new Vector3(3, 3, 3);
        minLocation = transform.position + new Vector3(-3, -3, -3);
    }

    private void Start()
    {
        audioSrc.clip = sfx_die;
        OnEnemyDie.AddListener(Die);
    }


    void Update()
    {
        if (health > 0)
        {
            if (!(maxLocation.x > transform.position.x && minLocation.x < transform.position.x))
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
            }

            if (!(maxLocation.y > transform.position.y && minLocation.y < transform.position.y))
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
            }

            if (!(maxLocation.z > transform.position.z && minLocation.z < transform.position.z))
            {
                transform.Rotate(new Vector3(0f, 180f, 0f));
            }

            transform.position += transform.forward * entityData.speed * Time.deltaTime;
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


}
