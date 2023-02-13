using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private Camera m_camera;
    [SerializeField] private int forceGravity = 5;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if (horizontalMovement == 1 || verticalMovement == 1 ||
            horizontalMovement == -1 || verticalMovement == -1)
        {
            transform.position += (transform.forward * verticalMovement + transform.right * horizontalMovement) * speed * Time.deltaTime;
        }

        Rotate(GetRotationInput());

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * forceGravity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void Rotate(Vector2 p_scrollDelta)
    {
        transform.Rotate(Vector3.up, p_scrollDelta.x * rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var l_mouseX = Input.GetAxis("Mouse X");
        var l_mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(l_mouseX, l_mouseY);
    }


}
