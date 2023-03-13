using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAim : MonoBehaviour
{
    [SerializeField] private float Distance;
    [SerializeField] private LayerMask layerToHit;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Raycast();
        }
    }

    private void Raycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Distance, layerToHit))
        {
            var rb = hit.rigidbody;
            if (rb != null)
            {
                switch (hit.collider.tag)
                {
                    case "Bat": case "Orc": case "Slime":
                        DestructibleEnemy enemyComponent = hit.collider.gameObject.GetComponentInParent<DestructibleEnemy>();
                        enemyComponent.RemoveHealth(1);
                        break;
                    case "Mage":
                        Mage mageComponent = hit.collider.gameObject.GetComponentInParent<Mage>();
                        mageComponent.health -= 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
