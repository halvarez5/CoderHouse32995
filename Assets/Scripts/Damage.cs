using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int damage;

    private void Awake()
    {
        damage = GetComponentInParent<Enemy>().entityData.damage;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player component = other.gameObject.GetComponent<Player>();
            component.RemoveHealth(damage);
        }
    }
}
