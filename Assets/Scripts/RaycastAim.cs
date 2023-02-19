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
                    case "Bat":
                        Bat batComponent = hit.collider.gameObject.GetComponentInParent<Bat>();
                        batComponent.health -= 1;
                        break;
                    case "Orc":
                        Orc orcComponent = hit.collider.gameObject.GetComponentInParent<Orc>();
                        orcComponent.health -= 1;
                        break;
                    case "Slime":
                        Slime slimeComponent = hit.collider.gameObject.GetComponentInParent<Slime>();
                        slimeComponent.health -= 1;
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
