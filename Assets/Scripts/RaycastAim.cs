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
                Debug.Log("disparando a " + hit.collider.gameObject.name);
                switch (hit.collider.tag)
                {
                    case "Enemy":
                        Bat component = hit.collider.gameObject.GetComponentInParent<Bat>();
                        component.health -= 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
