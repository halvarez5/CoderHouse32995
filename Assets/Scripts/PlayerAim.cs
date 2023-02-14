using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 750;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Rotate(GetRotationInput());
    }

    private void Rotate(Vector3 p_scrollDelta)
    {
        transform.Rotate(Vector3.left + Vector3.back, p_scrollDelta.x * p_scrollDelta.z * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector3 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector3(l_mouseX, 0, l_mouseY);
    }*/
}
